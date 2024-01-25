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
        internal string[] nameP = new string[5];
        internal string[] nameP2 = new string[6];

        public string[] parseName2(string name)
        {
            string str1 = Regex.Replace(name, @"\s+", " ");//likwiduje whitespace
            str1 = str1.Replace("KD", "kd");
            str1 = str1.Replace("RU", "kd");
            str1 = str1.Replace("SN", "sn");
            str1 = str1.Replace("PN", "pn");
            str1 = str1.Replace("INW", "inw");
            str1 = str1.Replace("kd /", "kd/");
            str1 = str1.Replace("ru /", "ru");
            str1 = str1.Replace("sn /", "sn/");
            str1 = str1.Replace("pn /", "pn/");
            str1 = str1.Replace("inw /", "inw/");
            str1 = str1.Replace("kd/ ", "kd/");
            str1 = str1.Replace("ru/ ", "ru");
            str1 = str1.Replace("sn/ ", "sn/");
            str1 = str1.Replace("pn/ ", "pn/");
            str1 = str1.Replace("inw/ ", "inw/");

            int snindex = str1.IndexOf("sn/");
            int ruindex = str1.IndexOf("ru/");
            int kdindex = str1.IndexOf("kd/");
            int pnindex = str1.IndexOf("pn/");
            int inwindex = str1.IndexOf("inw/");

            string snp, rup, kdp, pnp, inwp = "";
            //int next_space = 0;

            if (snindex != -1)//serial number
            {
                if (str1.IndexOf(' ', snindex + 1) < str1.Length)
                {
                    if (str1.IndexOf(' ', snindex + 1) != -1)
                    {
                        snp = str1.Substring(snindex + 3, str1.IndexOf(' ', snindex + 1) - snindex - 3);
                        //Console.WriteLine(snp);
                    }
                    else
                    {
                        snp = str1.Substring(snindex + 3, str1.Length - snindex - 3);
                        //Console.WriteLine(snp);
                    }
                }
                else
                {
                    if (snindex + 3 < str1.Length)
                        snp = str1.Substring(snindex + 3, str1.Length - snindex - 3);
                    else
                        snp = "";
                }

            }
            else
            {
                snp = "brak";
            }


            if (kdindex != -1)//kd number
            {
                if (str1.IndexOf(' ', kdindex + 1) < str1.Length)
                {
                    if (str1.IndexOf(' ', kdindex + 1) != -1)
                    {
                        kdp = str1.Substring(kdindex + 3, str1.IndexOf(' ', kdindex + 1) - kdindex - 3);
                        //Console.WriteLine(snp);
                    }
                    else
                    {
                        kdp = str1.Substring(kdindex + 3, str1.Length - kdindex - 3);
                        //Console.WriteLine(snp);
                    }
                }
                else
                {
                    if (kdindex + 3 < str1.Length)
                        kdp = str1.Substring(kdindex + 3, str1.Length - kdindex - 3);
                    else
                        kdp = "";
                }

            }
            else
            {
                kdp = "brak";
            }
            if (ruindex != -1)//ru number
            {
                if (str1.IndexOf(' ', ruindex + 1) < str1.Length)
                {
                    if (str1.IndexOf(' ', ruindex + 1) != -1)
                    {
                        rup = str1.Substring(ruindex + 3, str1.IndexOf(' ', ruindex + 1) - ruindex - 3);
                        //Console.WriteLine(rup);
                    }
                    else
                    {
                        rup = str1.Substring(ruindex + 3, str1.Length - ruindex - 3);
                        //Console.WriteLine(rup);
                    }
                }
                else
                {
                    if (snindex + 3 < str1.Length)
                        rup = str1.Substring(ruindex + 3, str1.Length - ruindex - 3);
                    else
                        rup = "";
                }

            }
            else
            {
                rup = "brak";
            }

            if (inwindex != -1)//inw number
            {
                if (str1.IndexOf(' ', inwindex + 1) < str1.Length)
                {
                    if (str1.IndexOf(' ', inwindex + 1) != -1)
                    {
                        inwp = str1.Substring(inwindex + 3, str1.IndexOf(' ', inwindex + 1) - inwindex - 3);
                        //Console.WriteLine(rup);
                    }
                    else
                    {
                        inwp = str1.Substring(inwindex + 3, str1.Length - inwindex - 3);
                        //Console.WriteLine(rup);
                    }
                }
                else
                {
                    if (inwindex + 3 < str1.Length)
                        inwp = str1.Substring(inwindex + 3, str1.Length - inwindex - 3);
                    else
                        inwp = "";
                }

            }
            else
            {
                inwp = "brak";
            }

            if (pnindex != -1)//pn number
            {
                if (str1.IndexOf(' ', pnindex + 1) < str1.Length)
                {
                    if (str1.IndexOf(' ', pnindex + 1) != -1)
                    {
                        pnp = str1.Substring(pnindex + 3, str1.IndexOf(' ', pnindex + 1) - pnindex - 3);
                        //Console.WriteLine(rup);
                    }
                    else
                    {
                        pnp = str1.Substring(pnindex + 3, str1.Length - pnindex - 3);
                        //Console.WriteLine(rup);
                    }
                }
                else
                {
                    if (pnindex + 3 < str1.Length)
                        pnp = str1.Substring(pnindex + 3, str1.Length - pnindex - 3);
                    else
                        pnp = "";
                }

            }
            else
            {
                pnp = "brak";
            }



            nameP2[0] = snp; //sn
            nameP2[1] = rup; //ru
            nameP2[2] = kdp; //kdp
            nameP2[3] = inwp; //inw
            nameP2[4] = pnp; //pn

            if (name.Contains("*"))
                nameP2[5] = "Nie";
            else
                nameP2[5] = "Tak";

           

            return nameP2;
        }

        public string[] parseName(string name)
        {
            
            string str1 = Regex.Replace(name, @"\s+", " ");//likwiduje whitespace
            str1 = str1.Replace("KD", "kd");
            str1 = str1.Replace("RU", "kd");
            str1 = str1.Replace("SN", "kd");
            str1 = str1.Replace("PN", "pn");
            str1 = str1.Replace("INW", "inw");
            int snindex = str1.IndexOf("sn/");
            int ruindex = str1.IndexOf("ru/");
            int kdindex = str1.IndexOf("kd/");
            string namep, snp, rup, kdp = "";
            int sl = 0;

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
                            if (kdindex - snindex - 3 <= 0)
                                sl = snindex + 3;
                            else
                                sl = kdindex - snindex - 3;

                            snp = str1.Substring(snindex + 3, sl);
                            namep = str1.Substring(0, snindex - 1);
                            int int_length = 0;
                            if (str1.Length - kdindex - 4 < 0)
                                int_length = 0;
                            else
                                int_length = str1.Length - kdindex - 4;
                                kdp = str1.Substring(kdindex + 3, int_length);
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


            if (name.Contains("*"))
                nameP[4] = "Nie";
            else
                nameP[4] = "Tak";

            nameP[0] = str1;
            nameP[1] = snp;
            nameP[2] = rup;
            nameP[3] = kdp;


            return nameP;
        }

    }
}
