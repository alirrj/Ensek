using ENSEK.DataAccess;
using ENSEK.Helpers;
using ENSEK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ENSEK.Services
{
    public class MeterService
    {
        public MeterStatus SaveMeterReaderList(IFormFile file)
        {
            var MeterList = new List<MeterReader>();
            var accountService = new AccountService();
            var accountList = accountService.GetAccountList();
            var meterStatus = new MeterStatus();
            var counter = 0;
            using (var reader = new StreamReader(file.OpenReadStream()))
{
                var format = @"dd/MM/yyyy h:mm";
                CultureInfo provider = CultureInfo.InvariantCulture;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    counter++;
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var meterReader = new MeterReader();
                    try
                    {
                        meterReader.AccountId = int.Parse(values[0]);
                        meterReader.MeterReadingDateTime = DateTime.ParseExact(values[1], format, provider);
                        meterReader.MeterReadValue = int.Parse(values[2]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    var isvalueInRange = meterReader.MeterReadValue > 10000 && meterReader.MeterReadValue < 99999;
                    var isAccountIdValid = accountList.Any(a => a.AccountId == meterReader.AccountId);
                    if (isAccountIdValid && isvalueInRange)
                        MeterList.Add(meterReader);
                }
            }
            var result = MeterList.Distinct().ToList();
            var ensekDbContext = new EnsekDbContext();
            ensekDbContext.MeterReader.AddRange(result);

            meterStatus.Successful = result.Count;
            meterStatus.Failed = counter - result.Count;
            return meterStatus;
        }
    }
}
