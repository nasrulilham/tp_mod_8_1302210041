using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302210041
{
    internal class CovidConfig
    {
        public class set
        {
            public string satuan_suhu { get; set; }
            public int batas_hari_demam { get; set; }
            public string pesan_ditolak { get; set; }
            public string pesan_diterima { get; set; }

            public set(string satuan_suhu, int batas_hari_demam, 
                string pesan_ditolak, string pesan_diterima)
            {
                this.satuan_suhu = satuan_suhu;
                this.batas_hari_demam = batas_hari_demam;
                this.pesan_ditolak = pesan_ditolak;
                this.pesan_diterima = pesan_diterima;
            }
            //setget
        }
        public class readWrite
        {
            public set config;
            public const string txt = @"./covid_config.json";

            private void SetDefault()
            {
                config = new set(
                    "celcius", 
                    14,
                    "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                    );
            }
            //method running config

            private void NewConfigFile()
            {
                JsonSerializerOptions dokumen = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(config, dokumen);
                File.WriteAllText(txt, jsonString);
            }
            //membuat filejson baru

            private set ReadConfigFile()
            {
                string readJSON = File.ReadAllText(txt);
                config = JsonSerializer.Deserialize<set>(readJSON);
                return config;
            }
            //membaca file

            public readWrite()
            {
                try
                {
                    ReadConfigFile();
                }
                catch (Exception)
                {
                    SetDefault();
                    NewConfigFile();
                }
            }
            //try catch, akan mencoba untuk readconfigfile terlebih dahulu bila tidak ada maka akan set default dan membuat yang baru

            public void UbahDerajat()
            {
                if (config.satuan_suhu == "celcius")
                {
                    config.satuan_suhu = "farenheit";
                    NewConfigFile();
                }
                else
                {
                    config.satuan_suhu = "celcius";
                    NewConfigFile();
                }
            }
            //mengubah ubah satuan celcius dan farenheit
        }
    }
}
