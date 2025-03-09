using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPCalismaSorulari
{
    public class Personel
    {
		private string _tcKimlikNo;

		public string TCKimlikNo
		{
			get //Yalnızca ilk 5 karakterini dönsün.
			{
				return _tcKimlikNo.Substring(0,5);
			}
			set //11 karakter olmalı ve sadece sayılardan oluşmalı
			{
				if(value.Length!=11)
				{
                    Console.WriteLine("Girdiğiniz TC Kimlik No 11 haneli değildir!");
                }
				else if(!SayiMi(value))
				{
                    Console.WriteLine("Girdiğiniz TC Kimlik No sadece rakamlardan oluşmalıdır!");
				}
				else
					_tcKimlikNo = value;
			}
		}
		private bool SayiMi(string strSayi)
		{
			bool sayiMi = false;
			for(int i = 0; i < strSayi.Length;i++)
			{
                sayiMi = char.IsNumber(strSayi[i]);
				if (!sayiMi)
					break;
            }
			return sayiMi;
		}

	}
}
