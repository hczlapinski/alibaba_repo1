using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestAPI_SymfoniaERP
{
    internal class AddFunctions
    {
      //  internal string name, ru, kd, sn = "";
        internal string[] nameP = new string[4];



        public string[] parseName(string name)
        {
            
            string str1 = Regex.Replace(name, @"\s+", " ");//likwiduje whitespace
            str1 = str1.Replace("KD", "kd");
            str1 = str1.Replace("RU", "kd");
            str1 = str1.Replace("SN", "kd");
            int snindex = str1.IndexOf("sn/");
            int ruindex = str1.IndexOf("ru/");
            int kdindex = str1.IndexOf("kd/");
            string namep, snp, rup, kdp = "";


            if (snindex < ruindex && snindex != -1)
            {
                namep = str1.Substring(0, snindex - 1);
                snp = str1.Substring(snindex + 3, str1.IndexOf(' ', snindex) - snindex - 3);
                rup = str1.Substring(ruindex + 3, str1.Length - ruindex - 3);


            }
            else if (ruindex < snindex && ruindex != -1)
            {
                namep = str1.Substring(0, ruindex - 1);
                rup = str1.Substring(ruindex + 3, str1.IndexOf(' ', ruindex) - ruindex - 3);
                snp = str1.Substring(snindex + 3, str1.Length - snindex - 3);

            }
            else if (ruindex == -1 && snindex == -1 && kdindex == -1)
            {
                namep = str1;
                snp = "brak";
                rup = "brak";
                kdp = "brak";
            }
            //brakuje sn lub ru
            else
            {

                //brakuje sn
                if (snindex == -1 && ruindex != -1)
                {
                    rup = str1.Substring(ruindex + 3, str1.Length - ruindex - 3);
                    namep = str1.Substring(0, ruindex - 1);
                    snp = "brak";
                }
                else
                {
                    if (kdindex != -1)
                    {
                        if (snindex != -1)
                        {
                            snp = str1.Substring(snindex + 3, kdindex - snindex - 3);
                            namep = str1.Substring(0, snindex - 1);
                            kdp = str1.Substring(kdindex + 3, str1.Length - kdindex - 4);
                            rup = "brak";
                        }
                        else
                        {
                            snp = "brak";
                            rup = "brak";
                            namep = str1.Substring(0, kdindex - 1);
                            kdp = str1.Substring(kdindex + 3, str1.Length - kdindex - 3);
                        }
                    }
                    else
                    {
                        snp = str1.Substring(snindex + 3, str1.Length - snindex - 3);
                        namep = str1.Substring(0, snindex - 1);
                        rup = "brak";
                    }
                }

               
            }

           

            nameP[0] = namep;
            nameP[1] = snp;
            nameP[2] = rup;
            nameP[3] = kdp;

            return nameP;
        }

    }
}
