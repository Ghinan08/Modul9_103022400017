using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Modul9_103022400017
{
    public class Config {

        public string lang { get; set; }
        public Transfer transfer;
        public List<string> methods { get; set; }
        public Confirmation confirmation;
        
        public Config() {
      
        }
        public Config(string lang, Transfer transfer,
            List<string> methods, Confirmation confirmation) { }


        public class Transfer
        {
            public double threshold { get; set; }
            public double low_fee { get; set; }
            public double high_fee { get; set; }
            public Transfer() { 
            }

            public Transfer(double threshold, double low_fee, double high_fee)
            {

            }


        }
        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
            public Confirmation(){   }

            public Confirmation(string en, string id)
            {

            }

        }

    }
    internal class BankTransferConfig
    {
        public Config config;
        private const string filepath = "bank_transfer_config.json";

        public BankTransferConfig() 
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteConfigFile();

            }
        }
        private void ReadConfigFile() { 
            string Json = File.ReadAllText (filepath);
            config = JsonSerializer.Deserialize<Config>(Json);
        }
        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() 
            { 
                 WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText (filepath, jsonString);
        }
        private void SetDefault()
        {
            config = new Config
            {
                threshold = 25000000,
                low_fee = 6500,
                high_fee =  15000,
                methods = [ "RTO (real-time) ", "SKN", "RTGS", "BI FAST" ]
                en = "yes",
                id = "ya"

            };
        }

    }
}
