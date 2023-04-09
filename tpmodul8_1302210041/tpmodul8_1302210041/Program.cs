// See https://aka.ms/new-console-template for more information


using static tpmodul8_1302210041.CovidConfig;

readWrite rw = new readWrite();
rw.UbahDerajat();


Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + rw.config.satuan_suhu);
Console.WriteLine("(celcius 36,5 - 37,5 atau 97.7 - 99,5)");
double suhu = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
int hari = Convert.ToInt32(Console.ReadLine());
//meminta masukan

if ((rw.config.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) && hari < rw.config.batas_hari_demam)
{
    Console.WriteLine(rw.config.pesan_diterima);
}
else if ((rw.config.satuan_suhu == "farenheit") && suhu >= 97.7 && suhu <= 99.5 && hari < rw.config.batas_hari_demam)
{
    Console.WriteLine(rw.config.pesan_diterima);
}
else
{
    Console.WriteLine(rw.config.pesan_ditolak);
}

//menentukuan range suhu untuk celcius dan farenheit, bila diluar hal tersbut maka pesan ditolak