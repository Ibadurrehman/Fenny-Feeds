using FennyFeeds.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FennyFeeds.HelperClasses
{
    public class MyHelperClass
    {
        public static string Get_IP_Address()
        {
            try
            {
                string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress))
                {
                    ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                //string userip = HttpContext.Current.Request.UserHostAddress;
                return ipAddress;
            }
            catch (Exception)
            { return ""; }
        }

        public static string GetProductCode()
        {
            try
            {
                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999); // creates a 8 digit random no.

                string ProductCode = "PRO-" + myRandomNo + DateTime.Now.Millisecond;
                return ProductCode;

            }
            catch (Exception)
            { return ""; }
        }


        //public static string DeleteProduct_Images(string imagepath)
        //{
        //    if (File.Exists(imagepath))
        //    {
        //        File.Delete(imagepath);
        //        return "done";
        //    }
        //    return Json("error", JsonRequestBehavior.AllowGet);
        //}


        public static List<string> GetProduct_Images(int PID)
        {
            //string[] fileArray = new string[] { };
            List<string> list = new List<string>();
            if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/content/Product_Image/" + PID + "/")))
            {
                //fileArray = Directory.GetFiles(HttpContext.Current.Server.MapPath("/content/Product_Image/" + PID + "/"));

                DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/content/Product_Image/" + PID + "/"));
                FileInfo[] Files = d.GetFiles();

                foreach (FileInfo file in Files)
                {
                    list.Add(file.Name);
                }

            }
            return list;
        }

        public static string[] GetBanner_Images()
        {
            string[] fileArray = new string[] { };
            if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/content/Banner_Image/")))
            {
                fileArray = Directory.GetFiles(HttpContext.Current.Server.MapPath("/content/Banner_Image/"));

            }
            return fileArray;
        }

        public static IEnumerable<SelectListItem> DropDownIsActive()
        {

            var Collection = Enum.GetValues(typeof(Enums.IsActive)).Cast<Enums.IsActive>();

            return (Collection.Select(s => new SelectListItem() { Text = s.ToString(), Value = s.GetHashCode().ToString() })).ToList();
        }

        public static IEnumerable<SelectListItem> DropdownGender()
        {
            var Collection = Enum.GetValues(typeof(Enums.Gender)).Cast<Enums.Gender>();

            return (Collection.Select(s => new SelectListItem() { Text = s.ToString(), Value = s.GetHashCode().ToString() })).ToList();

        }

        public static IEnumerable<SelectListItem> DropdownPet_Age()
        {
            IList<SelectListItem> pet_age = new List<SelectListItem>
            {
               new SelectListItem() {Value="Age Below 5 Year", Text="Age Below 5 Year"},
               new SelectListItem() {Value="Age Between 5-10 Year", Text="Age Between 5-10 Year"},
               new SelectListItem() {Value="Age Above 10 Year", Text="Age Above 10 Year"}
            };
            return pet_age;
        }

        public static IEnumerable<SelectListItem> DropdownPet_Weight()
        {
            IList<SelectListItem> pet_weight = new List<SelectListItem>
            {
               new SelectListItem() {Value="Weight Below 5 Kg", Text="Weight Below 5 Kg"},
               new SelectListItem() {Value="Weight Between 5-10 Kg", Text="Weight Between 5-10 Kg"},
               new SelectListItem() {Value="Weight Above 10 Kg", Text="Weight Above 10 Kg"}
            };
            return pet_weight;
        }

        public static IEnumerable<SelectListItem> DropdownPet_Breed()
        {
            IList<SelectListItem> pet_breed = new List<SelectListItem>
            {
               new SelectListItem() {Value="Pomeranian         ", Text="Pomeranian         "},
               new SelectListItem() {Value="German Shepherd    ", Text="German Shepherd    "},
               new SelectListItem() {Value="Labrador Retriever ", Text="Labrador Retriever "},
               new SelectListItem() {Value="Golden Retriever   ", Text="Golden Retriever   "},
               new SelectListItem() {Value="Great Dane         ", Text="Great Dane         "},
               new SelectListItem() {Value="Beagle             ", Text="Beagle             "},
               new SelectListItem() {Value="Bulldog            ", Text="Bulldog            "},
               new SelectListItem() {Value="Pug                ", Text="Pug                "},
               new SelectListItem() {Value="Doberman           ", Text="Doberman           "},
               new SelectListItem() {Value="Dachshund          ", Text="Dachshund          "},
               new SelectListItem() {Value="Rottweiler         ", Text="Rottweiler         "},
               new SelectListItem() {Value="Boxer              ", Text="Boxer              "},
               new SelectListItem() {Value="Dalmatian          ", Text="Dalmatian          "},
               new SelectListItem() {Value="Saint Bernard      ", Text="Saint Bernard      "},
               new SelectListItem() {Value="Bull Mastiff       ", Text="Bull Mastiff       "},
               new SelectListItem() {Value="French Mastiff     ", Text="French Mastiff     "},
               new SelectListItem() {Value="Siberian Husky     ", Text="Siberian Husky     "},
               new SelectListItem() {Value="Tibetan Mastiff    ", Text="Tibetan Mastiff    "},
               new SelectListItem() {Value="Pit Bull           ", Text="Pit Bull           "},
               new SelectListItem() {Value="Rhodesian Ridgeback", Text="Rhodesian Ridgeback"},
               new SelectListItem() {Value="Border Collie      ", Text="Border Collie      "}
                 
            };
            return pet_breed;
        }

        public static IEnumerable<SelectListItem> DropdownState()
        {
            IList<SelectListItem> state = new List<SelectListItem>
            {
               new SelectListItem() {Value="Andaman and Nicobar Islands", Text="Andaman and Nicobar Islands"},
               new SelectListItem() {Value="Andhra Pradesh", Text="Andhra Pradesh"},
               new SelectListItem() {Value="Arunachal Pradesh", Text="Arunachal Pradesh"},
               new SelectListItem() {Value="Assam", Text="Assam"},
               new SelectListItem() {Value="Bihar", Text="Bihar"},
               new SelectListItem() {Value="Chandigarh", Text="Chandigarh"},
               new SelectListItem() {Value="Chhattisgarh", Text="Chhattisgarh"},
               new SelectListItem() {Value="Dadra and Nagar Haveli", Text="Dadra and Nagar Haveli"},
               new SelectListItem() {Value="Daman and Diu", Text="Daman and Diu"},
               new SelectListItem() {Value="Delhi", Text="Delhi"},
               new SelectListItem() {Value="Goa", Text="Goa"},
               new SelectListItem() {Value="Gujarat", Text="Gujarat"},
               new SelectListItem() {Value="Haryana", Text="Haryana"},
               new SelectListItem() {Value="Himachal Pradesh", Text="Himachal Pradesh"},
               new SelectListItem() {Value="Jharkhand", Text="Jharkhand"},
               new SelectListItem() {Value="Karnataka", Text="Karnataka"},
               new SelectListItem() {Value="Kashmir", Text="Kashmir"},
               new SelectListItem() {Value="Kerala", Text="Kerala"},
               new SelectListItem() {Value="Laccadives", Text="Laccadives"},
               new SelectListItem() {Value="Madhya Pradesh", Text="Madhya Pradesh"},
               new SelectListItem() {Value="Maharashtra", Text="Maharashtra"},
               new SelectListItem() {Value="Manipur", Text="Manipur"},
               new SelectListItem() {Value="Meghalaya", Text="Meghalaya"},
               new SelectListItem() {Value="Mizoram", Text="Mizoram"},
               new SelectListItem() {Value="Nagaland", Text="Nagaland"},
               new SelectListItem() {Value="Odisha", Text="Odisha"},
               new SelectListItem() {Value="Punjab", Text="Punjab"},
               new SelectListItem() {Value="Rajasthan", Text="Rajasthan"},
               new SelectListItem() {Value="Sikkim", Text="Sikkim"},
               new SelectListItem() {Value="Tamil Nadu", Text="Tamil Nadu"},
               new SelectListItem() {Value="Telangana", Text="Telangana"},
               new SelectListItem() {Value="Tripura", Text="Tripura"},
               new SelectListItem() {Value="Uttarakhand", Text="Uttarakhand"},
               new SelectListItem() {Value="Uttar Pradesh", Text="Uttar Pradesh"},
               new SelectListItem() {Value="West Bengal", Text="West Bengal"}
                 
            };
            return state;
        }

        public static IEnumerable<SelectListItem> DropdownCity()
        {
            IList<SelectListItem> city = new List<SelectListItem>
            {
               new SelectListItem() {Value="Agartala                ", Text="Agartala                     "},
               new SelectListItem() {Value="Agra                    ", Text="Agra                         "},
               new SelectListItem() {Value="Ahmedabad               ", Text="Ahmedabad                    "},
               new SelectListItem() {Value="Ahmednagar              ", Text="Ahmednagar                   "},
               new SelectListItem() {Value="Aizwal                  ", Text="Aizwal                       "},
               new SelectListItem() {Value="Ajmer                   ", Text="Ajmer                        "},
               new SelectListItem() {Value="Akola                   ", Text="Akola                        "},
               new SelectListItem() {Value="Aligarh                 ", Text="Aligarh                      "},
               new SelectListItem() {Value="Allahabad               ", Text="Allahabad                    "},
               new SelectListItem() {Value="Alwar                   ", Text="Alwar                        "},
               new SelectListItem() {Value="Ambala                  ", Text="Ambala                       "},
               new SelectListItem() {Value="Amravati                ", Text="Amravati                     "},
               new SelectListItem() {Value="Amreli                  ", Text="Amreli                       "},
               new SelectListItem() {Value="Amritsar                ", Text="Amritsar                     "},
               new SelectListItem() {Value="Anand                   ", Text="Anand                        "},
               new SelectListItem() {Value="Anantapur               ", Text="Anantapur                    "},
               new SelectListItem() {Value="Anklesvar               ", Text="Anklesvar                    "},
               new SelectListItem() {Value="Anuppur                 ", Text="Anuppur                      "},
               new SelectListItem() {Value="Araria                  ", Text="Araria                       "},
               new SelectListItem() {Value="Arcot                   ", Text="Arcot                        "},
               new SelectListItem() {Value="Arrah                   ", Text="Arrah                        "},
               new SelectListItem() {Value="Aruppukkottai           ", Text="Aruppukkottai                "},
               new SelectListItem() {Value="Asansol                 ", Text="Asansol                      "},
               new SelectListItem() {Value="Ashok Nagar             ", Text="Ashok Nagar                  "},
               new SelectListItem() {Value="Aurangabad, Bihar       ", Text="Aurangabad, Bihar            "},
               new SelectListItem() {Value="Aurangabad, Maharashtra ", Text="Aurangabad, Maharashtra      "},
               new SelectListItem() {Value="Azamgarh             ", Text="Azamgarh                                          "},
               new SelectListItem() {Value="Bahadurgarh          ", Text="Bahadurgarh                                       "},
               new SelectListItem() {Value="Baharampur           ", Text="Baharampur                                        "},
               new SelectListItem() {Value="Bahraich             ", Text="Bahraich                                          "},
               new SelectListItem() {Value="Balaghat             ", Text="Balaghat                                          "},
               new SelectListItem() {Value="Balangir Orissa      ", Text="Balangir Orissa                                   "},
               new SelectListItem() {Value="Balasore             ", Text="Balasore                                          "},
               new SelectListItem() {Value="Balia                ", Text="Balia                                             "},
               new SelectListItem() {Value="Ballabhgarh          ", Text="Ballabhgarh                                       "},
               new SelectListItem() {Value="Ballarpur            ", Text="Ballarpur                                         "},
               new SelectListItem() {Value="Balrampur            ", Text="Balrampur                                         "},
               new SelectListItem() {Value="Balurghat West Bengal", Text="Balurghat West Bengal                             "},
               new SelectListItem() {Value="Banda ", Text="Banda "},
               new SelectListItem() {Value="Bangalore ", Text="Bangalore "},
               new SelectListItem() {Value="Banganapalle ", Text="Banganapalle "},
               new SelectListItem() {Value="Banswara ", Text="Banswara "},
               new SelectListItem() {Value="Banswara ", Text="Banswara "},
               new SelectListItem() {Value="Banur ", Text="Banur "},
               new SelectListItem() {Value="baran ", Text="baran "},
               new SelectListItem() {Value="Bardhaman ", Text="Bardhaman "},
               new SelectListItem() {Value="Bareilly ", Text="Bareilly "},
               new SelectListItem() {Value="Barh ", Text="Barh "},
               new SelectListItem() {Value="Baripada ", Text="Baripada "},
               new SelectListItem() {Value="Barmer ", Text="Barmer "},
               new SelectListItem() {Value="Barrackpur ", Text="Barrackpur "},
               new SelectListItem() {Value="Barwani ", Text="Barwani "},
               new SelectListItem() {Value="Beawar ", Text="Beawar "},
               new SelectListItem() {Value="Belgaum ", Text="Belgaum "},
               new SelectListItem() {Value="Bellary ", Text="Bellary "},
               new SelectListItem() {Value="Bengaluru ", Text="Bengaluru "},
               new SelectListItem() {Value="Betul ", Text="Betul "},
               new SelectListItem() {Value="Bhagalpur ", Text="Bhagalpur "},
               new SelectListItem() {Value="Bhandara ", Text="Bhandara "},
               new SelectListItem() {Value="Bharatpur ", Text="Bharatpur "},
               new SelectListItem() {Value="Bharuch ", Text="Bharuch "},
               new SelectListItem() {Value="Bhavani ", Text="Bhavani "},
               new SelectListItem() {Value="Bhavnagar ", Text="Bhavnagar "},
               new SelectListItem() {Value="Bhilai Nagar ", Text="Bhilai Nagar "},
               new SelectListItem() {Value="Bhimavaram ", Text="Bhimavaram "},
               new SelectListItem() {Value="Bhiwandi ", Text="Bhiwandi "},
               new SelectListItem() {Value="Bhopal ", Text="Bhopal "},
               new SelectListItem() {Value="Bhubaneswar ", Text="Bhubaneswar "},
               new SelectListItem() {Value="Bhuj ", Text="Bhuj "},
               new SelectListItem() {Value="Bidar ", Text="Bidar "},
               new SelectListItem() {Value="Bihar Sharif ", Text="Bihar Sharif "},
               new SelectListItem() {Value="Bijnaur, UP ", Text="Bijnaur, UP "},
               new SelectListItem() {Value="Bikaner ", Text="Bikaner "},
               new SelectListItem() {Value="Bilaspur, Chhattisgarh ", Text="Bilaspur, Chhattisgarh "},
               new SelectListItem() {Value="Bilaspur, Himachal Pradesh ", Text="Bilaspur, Himachal Pradesh "},
               new SelectListItem() {Value="Bilgha, Punjab ", Text="Bilgha, Punjab "},
               new SelectListItem() {Value="Bodh Gaya ", Text="Bodh Gaya "},
               new SelectListItem() {Value="Bokaro Steel City ", Text="Bokaro Steel City "},
               new SelectListItem() {Value="Bongaigaon ", Text="Bongaigaon "},
               new SelectListItem() {Value="Bulandshahr ", Text="Bulandshahr "},
               new SelectListItem() {Value="Buldana ", Text="Buldana "},
               new SelectListItem() {Value="Burhanpur ", Text="Burhanpur "},
               new SelectListItem() {Value="Buxar ", Text="Buxar "},
               new SelectListItem() {Value="Cambay ", Text="Cambay "},
               new SelectListItem() {Value="Caryobys ", Text="Caryobys "},
               new SelectListItem() {Value="Chamoli Gopeshwar ", Text="Chamoli Gopeshwar "},
               new SelectListItem() {Value="Champawat ", Text="Champawat "},
               new SelectListItem() {Value="Chamrajnagar ", Text="Chamrajnagar "},
               new SelectListItem() {Value="Chandannagar ", Text="Chandannagar "},
               new SelectListItem() {Value="Chandigarh ", Text="Chandigarh "},
               new SelectListItem() {Value="Chandrapur ", Text="Chandrapur "},
               new SelectListItem() {Value="Chapra ", Text="Chapra "},
               new SelectListItem() {Value="Charkhari ", Text="Charkhari "},
               new SelectListItem() {Value="Chengalpattu ", Text="Chengalpattu "},
               new SelectListItem() {Value="Chennai ", Text="Chennai "},
               new SelectListItem() {Value="Chhatarpur ", Text="Chhatarpur "},
               new SelectListItem() {Value="Chhindwara ", Text="Chhindwara "},
               new SelectListItem() {Value="Chikmagalur ", Text="Chikmagalur "},
               new SelectListItem() {Value="Chiplun ", Text="Chiplun "},
               new SelectListItem() {Value="Chitradurga           ", Text="Chitradurga                         "},
               new SelectListItem() {Value="Chitrakoot Dham Karwi ", Text="Chitrakoot Dham Karwi               "},
               new SelectListItem() {Value="Chittoor              ", Text="Chittoor                                            "},
               new SelectListItem() {Value="Coimbatore            ", Text="Coimbatore                      "},
               new SelectListItem() {Value="Contai                ", Text="Contai                          "},
               new SelectListItem() {Value="Coonoor               ", Text="Coonoor                 "},
               new SelectListItem() {Value="Cuddalore             ", Text="Cuddalore                               "},
               new SelectListItem() {Value="Cuddapah              ", Text="Cuddapah                                "},
               new SelectListItem() {Value="Cuttack               ", Text="Cuttack                         "},
               new SelectListItem() {Value="Dabra                 ", Text="Dabra                                   "},
               new SelectListItem() {Value="Dadra                 ", Text="Dadra                                   "},
               new SelectListItem() {Value="Dahod                 ", Text="Dahod                                   "},
               new SelectListItem() {Value="Daksh                 ", Text="Daksh                                   "},
               new SelectListItem() {Value="Daltonganj            ", Text="Daltonganj                      "},
               new SelectListItem() {Value="Daman                 ", Text="Daman                           "},
               new SelectListItem() {Value="Damoh                 ", Text="Damoh                           "},
               new SelectListItem() {Value="Darbhanga             ", Text="Darbhanga                   "},
               new SelectListItem() {Value="Darjeeling            ", Text="Darjeeling              "},
               new SelectListItem() {Value="Datia                 ", Text="Datia                   "},
               new SelectListItem() {Value="Davanagere            ", Text="Davanagere                  "},
               new SelectListItem() {Value="Dehgam                ", Text="Dehgam                      "},
               new SelectListItem() {Value="Dehradun              ", Text="Dehradun                "},
               new SelectListItem() {Value="Delhi                 ", Text="Delhi                   "},
               new SelectListItem() {Value="Deoghar               ", Text="Deoghar                 "},
               new SelectListItem() {Value="Dewas                 ", Text="Dewas                   "},
               new SelectListItem() {Value="Dhanbad               ", Text="Dhanbad                 "},
               new SelectListItem() {Value="Dhar                  ", Text="Dhar                    "},
               new SelectListItem() {Value="Dharampur             ", Text="Dharampur                   "},
               new SelectListItem() {Value="Dharamsala            ", Text="Dharamsala              "},
               new SelectListItem() {Value="Dharwad               ", Text="Dharwad                 "},
               new SelectListItem() {Value="Dholka                ", Text="Dholka                  "},
               new SelectListItem() {Value="Dhule                 ", Text="Dhule                       "},
               new SelectListItem() {Value="Dhulian               ", Text="Dhulian                 "},
               new SelectListItem() {Value="Dibrugarh             ", Text="Dibrugarh                   "},
               new SelectListItem() {Value="Dindigul              ", Text="Dindigul                    "},
               new SelectListItem() {Value="Dispur                ", Text="Dispur                  "},
               new SelectListItem() {Value="Diu                   ", Text="Diu                     "},
               new SelectListItem() {Value="Dombivli        ", Text="Dombivli                                    "},
               new SelectListItem() {Value="Duhbai          ", Text="Duhbai                              "},
               new SelectListItem() {Value="Dumdum          ", Text="Dumdum                                                      "},
               new SelectListItem() {Value="Durg            ", Text="Durg                                            "},
               new SelectListItem() {Value="Durgapur        ", Text="Durgapur                        "},
               new SelectListItem() {Value="Dwarka          ", Text="Dwarka                              "},
               new SelectListItem() {Value="Ernakulam       ", Text="Ernakulam                                   "},
               new SelectListItem() {Value="Erode           ", Text="Erode                                       "},
               new SelectListItem() {Value="Etah            ", Text="Etah                            "},
               new SelectListItem() {Value="Etawah          ", Text="Etawah                          "},
               new SelectListItem() {Value="Faizabad        ", Text="Faizabad                        "},
               new SelectListItem() {Value="Faridabad       ", Text="Faridabad                                           "},
               new SelectListItem() {Value="Faridkot        ", Text="Faridkot                                            "},
               new SelectListItem() {Value="Farrukhabad     ", Text="Farrukhabad                                 "},
               new SelectListItem() {Value="Fatehgarh       ", Text="Fatehgarh                               "},
               new SelectListItem() {Value="Fatehpur Sikri  ", Text="Fatehpur Sikri                                  "},
               new SelectListItem() {Value="Ferozepur Cantt.", Text="Ferozepur Cantt.                                        "},
               new SelectListItem() {Value="Ferozepur City  ", Text="Ferozepur City                                          "},
               new SelectListItem() {Value="Firozabad       ", Text="Firozabad                                       "},
               new SelectListItem() {Value="Gadchiroli      ", Text="Gadchiroli                                          "},
               new SelectListItem() {Value="Gandhinagar     ", Text="Gandhinagar                                             "},
               new SelectListItem() {Value="Gangtok         ", Text="Gangtok                                             "},
               new SelectListItem() {Value="Ganjam          ", Text="Ganjam                                      "},
               new SelectListItem() {Value="Garcha, Punjab  ", Text="Garcha, Punjab                               "},
               new SelectListItem() {Value="Gaya            ", Text="Gaya                                        "},
               new SelectListItem() {Value="Ghaziabad       ", Text="Ghaziabad                               "},
               new SelectListItem() {Value="Ghazipur        ", Text="Ghazipur                                 "},
               new SelectListItem() {Value="Goa Velha                 ", Text="Goa Velha                                                "},
               new SelectListItem() {Value="Godhra                    ", Text="Godhra                          "},
               new SelectListItem() {Value="Gondiya                   ", Text="Gondiya                         "},
               new SelectListItem() {Value="Gorakhpur                 ", Text="Gorakhpur                                            "},
               new SelectListItem() {Value="Greater                   ", Text="Greater                                                 Noida "},
               new SelectListItem() {Value="Gudalur                   ", Text="Gudalur                          "},
               new SelectListItem() {Value="Gudivada                  ", Text="Gudivada                                            "},
               new SelectListItem() {Value="Gulbarga                  ", Text="Gulbarga                                             "},
               new SelectListItem() {Value="Gumla                     ", Text="Gumla                                    "},
               new SelectListItem() {Value="Guna                      ", Text="Guna                        "},
               new SelectListItem() {Value="Gundlupet                 ", Text="Gundlupet                                "},
               new SelectListItem() {Value="Guntur                    ", Text="Guntur                                               "},
               new SelectListItem() {Value="Gurgaon                   ", Text="Gurgaon                                     "},
               new SelectListItem() {Value="Guruharsahai              ", Text="Guruharsahai                                                 "},
               new SelectListItem() {Value="Guwahati                  ", Text="Guwahati                                "},
               new SelectListItem() {Value="Gwalior                   ", Text="Gwalior                                                     "},
               new SelectListItem() {Value="Haldia                    ", Text="Haldia                                      "},
               new SelectListItem() {Value="Haldwani                  ", Text="Haldwani                                            "},
               new SelectListItem() {Value="Hamir, Uttar Pradesh      ", Text="Hamir, Uttar Pradesh                                         "},
               new SelectListItem() {Value="Hamirpur, Himachal Pradesh", Text="Hamirpur, Himachal Pradesh                              "},
               new SelectListItem() {Value="Hansi                     ", Text="Hansi                                "},
               new SelectListItem() {Value="Hanumangarh               ", Text="Hanumangarh                                             "},
               new SelectListItem() {Value="Harda                     ", Text="Harda                                    "},
               new SelectListItem() {Value="Haridwar                  ", Text="Haridwar                                         "},
               new SelectListItem() {Value="Harsawa                   ", Text="Harsawa                             "},
               new SelectListItem() {Value="Hassan                    ", Text="Hassan                                          "},
               new SelectListItem() {Value="Hastinapur                ", Text="Hastinapur                                               "},
               new SelectListItem() {Value="Hathras                   ", Text="Hathras                                                 "},
               new SelectListItem() {Value="Hatigudda, Karnataka      ", Text="Hatigudda, Karnataka                                                                 "},
               new SelectListItem() {Value="Himatnagar                ", Text="Himatnagar                                                  "},
               new SelectListItem() {Value="hindupur                  ", Text="hindupur                                                "},
               new SelectListItem() {Value="Hisar                     ", Text="Hisar                                            "},
               new SelectListItem() {Value="Hoshiarpur                ", Text="Hoshiarpur                                                  "},
               new SelectListItem() {Value="Howrah                    ", Text="Howrah                                      "},
               new SelectListItem() {Value="Hubli                     ", Text="Hubli                                               "},
               new SelectListItem() {Value="Hyderabad, Andhra Pradesh ", Text="Hyderabad, Andhra Pradesh                                                   "},
               new SelectListItem() {Value="Indore                    ", Text="Indore                                                  "},
               new SelectListItem() {Value="Irinjalakuda              ", Text="Irinjalakuda                                                     "},
               new SelectListItem() {Value="Jabalpur                  ", Text="Jabalpur                                            "},
               new SelectListItem() {Value="Jagraon                   ", Text="Jagraon                                                             "},
               new SelectListItem() {Value="Jagtial                   ", Text="Jagtial                                              "},
               new SelectListItem() {Value="Jaipur                    ", Text="Jaipur                                          "},
               new SelectListItem() {Value="Jais                      ", Text="Jais                                                        "},
               new SelectListItem() {Value="Jaisalmer                 ", Text="Jaisalmer                                            "},
               new SelectListItem() {Value="Jalalabad                 ", Text="Jalalabad                                                    "},
               new SelectListItem() {Value="Jalandhar                 ", Text="Jalandhar                                                    "},
               new SelectListItem() {Value="Jalgaon                   ", Text="Jalgaon                                             "},
               new SelectListItem() {Value="Jammu                     ", Text="Jammu                                                "},
               new SelectListItem() {Value="Jamnagar                  ", Text="Jamnagar                             "},
               new SelectListItem() {Value="Jamshedpur                ", Text="Jamshedpur                               "},
               new SelectListItem() {Value="Jaunpur                   ", Text="Jaunpur                                             "},
               new SelectListItem() {Value="Jhabua                    ", Text="Jhabua                                              "},
               new SelectListItem() {Value="Jhalawar                  ", Text="Jhalawar                                    "},
               new SelectListItem() {Value="Jhansi          ", Text="Jhansi                                                  "},
               new SelectListItem() {Value="Jhunjhunu       ", Text="Jhunjhunu                                                    "},
               new SelectListItem() {Value="Jodhpur         ", Text="Jodhpur                                                     "},
               new SelectListItem() {Value="Jorhat          ", Text="Jorhat                                              "},
               new SelectListItem() {Value="Junagadh        ", Text="Junagadh                                             "},
               new SelectListItem() {Value="Kakinada        ", Text="Kakinada                                                         "},
               new SelectListItem() {Value="Kalimpong       ", Text="Kalimpong                                       "},
               new SelectListItem() {Value="Kalwa           ", Text="Kalwa                                                   "},
               new SelectListItem() {Value="Kalyan-Dombivali", Text="Kalyan-Dombivali                                                        "},
               new SelectListItem() {Value="Kalyani         ", Text="Kalyani                                             "},
               new SelectListItem() {Value="Kanauj          ", Text="Kanauj                                          "},
               new SelectListItem() {Value="Kancheepuram    ", Text="Kancheepuram                            "},
               new SelectListItem() {Value="Kandla          ", Text="Kandla                                      "},
               new SelectListItem() {Value="Kangazha        ", Text="Kangazha                                        "},
               new SelectListItem() {Value="Kannur          ", Text="Kannur                                          "},
               new SelectListItem() {Value="Kanyakumari     ", Text="Kanyakumari                                                     "},
               new SelectListItem() {Value="Karaikal        ", Text="Karaikal                                        "},
               new SelectListItem() {Value="Karaikudi       ", Text="Karaikudi                                       "},
               new SelectListItem() {Value="Karamsad        ", Text="Karamsad                                                    "},
               new SelectListItem() {Value="Karimnagar      ", Text="Karimnagar                                   "},
               new SelectListItem() {Value="Karjat          ", Text="Karjat                                          "},
               new SelectListItem() {Value="Karnal          ", Text="Karnal                                          "},
               new SelectListItem() {Value="Karur           ", Text="Karur                                               "},
               new SelectListItem() {Value="Karwar          ", Text="Karwar                                      "},
               new SelectListItem() {Value="Kavaratti       ", Text="Kavaratti                                                   "},
               new SelectListItem() {Value="Khamanon        ", Text="Khamanon                                            "},
               new SelectListItem() {Value="Khammam         ", Text="Khammam                                         "},
               new SelectListItem() {Value="Khandwa         ", Text="Khandwa                                                     "},
               new SelectListItem() {Value="Khanna          ", Text="Khanna                                               "},
               new SelectListItem() {Value="Kharagpur        ", Text="Kharagpur                                                           "},
               new SelectListItem() {Value="Khargone         ", Text="Khargone                                            "},
               new SelectListItem() {Value="Kheda            ", Text="Kheda                                               "},
               new SelectListItem() {Value="Khilchipur       ", Text="Khilchipur                                                       "},
               new SelectListItem() {Value="Khopoli          ", Text="Khopoli                                 "},
               new SelectListItem() {Value="Khuldabad        ", Text="Khuldabad                                                       "},
               new SelectListItem() {Value="Kirandul         ", Text="Kirandul                                         "},
               new SelectListItem() {Value="Kochi            ", Text="Kochi                                                   "},
               new SelectListItem() {Value="Kohima           ", Text="Kohima                                                   "},
               new SelectListItem() {Value="Kokrajhar        ", Text="Kokrajhar                                               "},
               new SelectListItem() {Value="Kolar            ", Text="Kolar                                       "},
               new SelectListItem() {Value="Kolhapur         ", Text="Kolhapur                                             "},
               new SelectListItem() {Value="Kolkata          ", Text="Kolkata                                     "},
               new SelectListItem() {Value="Kollam           ", Text="Kollam                                              "},
               new SelectListItem() {Value="Konark           ", Text="Konark                                   "},
               new SelectListItem() {Value="Korba            ", Text="Korba                                                   "},
               new SelectListItem() {Value="Kota             ", Text="Kota                                            "},
               new SelectListItem() {Value="Kotdwara         ", Text="Kotdwara                                            "},
               new SelectListItem() {Value="Kothagudem       ", Text="Kothagudem                                              "},
               new SelectListItem() {Value="Kothamangalam    ", Text="Kothamangalam                                       "},
               new SelectListItem() {Value="Kottarakara      ", Text="Kottarakara                                                     "},
               new SelectListItem() {Value="Kottayam         ", Text="Kottayam                                            "},
               new SelectListItem() {Value="Kovilpatti       ", Text="Kovilpatti                                              "},
               new SelectListItem() {Value="Koyampattur      ", Text="Koyampattur                                     "},
               new SelectListItem() {Value="Kozhencherry     ", Text="Kozhencherry                                        "},
               new SelectListItem() {Value="Kozhikode        ", Text="Kozhikode                                           "},
               new SelectListItem() {Value="Krishnagiri      ", Text="Krishnagiri                                             "},
               new SelectListItem() {Value="Kulpahar         ", Text="Kulpahar                                    "},
               new SelectListItem() {Value="Kumbakonam       ", Text="Kumbakonam                                      "},
               new SelectListItem() {Value="Kumbhraj         ", Text="Kumbhraj                                        "},
               new SelectListItem() {Value="Kurnool          ", Text="Kurnool                                 "},
               new SelectListItem() {Value="kurukshetra]     ", Text="kurukshetra]                                "},
               new SelectListItem() {Value="Kushinagar       ", Text="Kushinagar                          "},
               new SelectListItem() {Value="Lalitpur         ", Text="Lalitpur                                 "},
               new SelectListItem() {Value="Lamka          ", Text="Lamka                                           "},
               new SelectListItem() {Value="Leh            ", Text="Leh                                     "},
               new SelectListItem() {Value="Lucknow        ", Text="Lucknow                                                 "},
               new SelectListItem() {Value="Ludhiana       ", Text="Ludhiana                                            "},
               new SelectListItem() {Value="Machilipatnam  ", Text="Machilipatnam                                                           "},
               new SelectListItem() {Value="Madanapalle    ", Text="Madanapalle                         "},
               new SelectListItem() {Value="Madgaon        ", Text="Madgaon                                  "},
               new SelectListItem() {Value="Madikeri       ", Text="Madikeri                                        "},
               new SelectListItem() {Value="Madurai        ", Text="Madurai                                              "},
               new SelectListItem() {Value="Mahabaleswar   ", Text="Mahabaleswar                                         "},
               new SelectListItem() {Value="Mahabubnagar   ", Text="Mahabubnagar                                        "},
               new SelectListItem() {Value="Mahad          ", Text="Mahad                                   "},
               new SelectListItem() {Value="Mahe           ", Text="Mahe                            "},
               new SelectListItem() {Value="Mahoba         ", Text="Mahoba                                          "},
               new SelectListItem() {Value="Mahwa          ", Text="Mahwa                                                    "},
               new SelectListItem() {Value="Malout         ", Text="Malout                                  "},
               new SelectListItem() {Value="Mandsaur       ", Text="Mandsaur                                        "},
               new SelectListItem() {Value="Mangalagiri    ", Text="Mangalagiri                                          "},
               new SelectListItem() {Value="Mangalore      ", Text="Mangalore                                    "},
               new SelectListItem() {Value="Mapusa         ", Text="Mapusa                                      "},
               new SelectListItem() {Value="Marmagao       ", Text="Marmagao                                         "},
               new SelectListItem() {Value="Mathura        ", Text="Mathura                                     "},
               new SelectListItem() {Value="Meerut         ", Text="Meerut                                          "},
               new SelectListItem() {Value="Melattur       ", Text="Melattur                                         "},
               new SelectListItem() {Value="Mirzapur       ", Text="Mirzapur                                                     "},
               new SelectListItem() {Value="Moga           ", Text="Moga                                            "},
               new SelectListItem() {Value="Mohali         ", Text="Mohali                                              "},
               new SelectListItem() {Value="Mokama         ", Text="Mokama                                              "},
               new SelectListItem() {Value="Moradabad      ", Text="Moradabad                            "},
               new SelectListItem() {Value="Motihari       ", Text="Motihari                                        "},
               new SelectListItem() {Value="Mount Abu      ", Text="Mount Abu                                                               "},
               new SelectListItem() {Value="Mukatsar       ", Text="Mukatsar                                     "},
               new SelectListItem() {Value="Mullanpur      ", Text="Mullanpur                               "},
               new SelectListItem() {Value="Mumbai              ", Text="Mumbai                                       "},
               new SelectListItem() {Value="Murshidabad         ", Text="Murshidabad                                  "},
               new SelectListItem() {Value="Murwara             ", Text="Murwara                                             "},
               new SelectListItem() {Value="Mussoorie           ", Text="Mussoorie                           "},
               new SelectListItem() {Value="Muzaffarnagar       ", Text="Muzaffarnagar                                "},
               new SelectListItem() {Value="Muzaffarpur         ", Text="Muzaffarpur                                         "},
               new SelectListItem() {Value="Mysore              ", Text="Mysore                                  "},
               new SelectListItem() {Value="Nadiad              ", Text="Nadiad                              "},
               new SelectListItem() {Value="Nagapattinam        ", Text="Nagapattinam                                "},
               new SelectListItem() {Value="Nagarkurnool        ", Text="Nagarkurnool                                "},
               new SelectListItem() {Value="Nagercoil           ", Text="Nagercoil                           "},
               new SelectListItem() {Value="Nagina, UP          ", Text="Nagina, UP                      "},
               new SelectListItem() {Value="Nagpur              ", Text="Nagpur                              "},
               new SelectListItem() {Value="Nainital            ", Text="Nainital                            "},
               new SelectListItem() {Value="Nalgonda            ", Text="Nalgonda                                "},
               new SelectListItem() {Value="Nanded              ", Text="Nanded                              "},
               new SelectListItem() {Value="Nandurbar           ", Text="Nandurbar                                                    "},
               new SelectListItem() {Value="Nandyal             ", Text="Nandyal                                 "},
               new SelectListItem() {Value="Nanital             ", Text="Nanital                                 "},
               new SelectListItem() {Value="Narasaraopet        ", Text="Narasaraopet                                    "},
               new SelectListItem() {Value="Narnol              ", Text="Narnol                                      "},
               new SelectListItem() {Value="Narsimhapur         ", Text="Narsimhapur                                     "},
               new SelectListItem() {Value="Narsinghgarh        ", Text="Narsinghgarh                                        "},
               new SelectListItem() {Value="Nashik              ", Text="Nashik                                      "},
               new SelectListItem() {Value="Navi Mumbai         ", Text="Navi Mumbai                                      "},
               new SelectListItem() {Value="Navsari             ", Text="Navsari                                             "},
               new SelectListItem() {Value="Nawalgarh           ", Text="Nawalgarh                               "},
               new SelectListItem() {Value="Neemuch             ", Text="Neemuch                                                      "},
               new SelectListItem() {Value="Nellore             ", Text="Nellore                                              "},
               new SelectListItem() {Value="New Delhi* or Delhi ", Text="New Delhi* or Delhi                                              "},
               new SelectListItem() {Value="New Guntur          ", Text="New Guntur                                               "},
               new SelectListItem() {Value="Nizamabad           ", Text="Nizamabad                                           "},
               new SelectListItem() {Value="Noida               ", Text="Noida                               "},
               new SelectListItem() {Value="Nurmahal, Punjab    ", Text="Nurmahal, Punjab                                         "},
               new SelectListItem() {Value="Nurpur, Himachal Pradesh ", Text="Nurpur, Himachal Pradesh                                        "},
               new SelectListItem() {Value="Palghat                  ", Text="Palghat                                                      "},
               new SelectListItem() {Value="Palwal                   ", Text="Palwal                                  "},
               new SelectListItem() {Value="Panaji                   ", Text="Panaji                              "},
               new SelectListItem() {Value="Panchkula                ", Text="Panchkula                                                   "},
               new SelectListItem() {Value="Pandharpur               ", Text="Pandharpur                                  "},
               new SelectListItem() {Value="Panipat                  ", Text="Panipat                             "},
               new SelectListItem() {Value="Panna                    ", Text="Panna                               "},
               new SelectListItem() {Value="Panvel                   ", Text="Panvel                          "},
               new SelectListItem() {Value="Pasla, Punjab            ", Text="Pasla, Punjab                                   "},
               new SelectListItem() {Value="Patan                    ", Text="Patan                       "},
               new SelectListItem() {Value="Pathankot                ", Text="Pathankot                               "},
               new SelectListItem() {Value="Patiala                  ", Text="Patiala                                                         "},
               new SelectListItem() {Value="Patna                    ", Text="Patna                                       "},
               new SelectListItem() {Value="Patratu,Jharkhand        ", Text="Patratu,Jharkhand                                           "},
               new SelectListItem() {Value="Pimpri Chinchwad         ", Text="Pimpri Chinchwad                                         "},
               new SelectListItem() {Value="Ponda                    ", Text="Ponda                               "},
               new SelectListItem() {Value="Porbandar                ", Text="Porbandar                                               "},
               new SelectListItem() {Value="Port Blair               ", Text="Port Blair                               "},
               new SelectListItem() {Value="Pratapgarh               ", Text="Pratapgarh                      "},
               new SelectListItem() {Value="Puducherry               ", Text="Puducherry                      "},
               new SelectListItem() {Value="Punalur                  ", Text="Punalur                             "},
               new SelectListItem() {Value="Pune                     ", Text="Pune                                 "},
               new SelectListItem() {Value="Puri                     ", Text="Puri                        "},
               new SelectListItem() {Value="Pushkar                  ", Text="Pushkar                       "},
               new SelectListItem() {Value="Quilon                   ", Text="Quilon                              "},
               new SelectListItem() {Value="Rae Bareli               ", Text="Rae Bareli                          "},
               new SelectListItem() {Value="Raichur                  ", Text="Raichur                         "},
               new SelectListItem() {Value="Raigarh                  ", Text="Raigarh                                     "},
               new SelectListItem() {Value="Raipur                   ", Text="Raipur                                          "},
               new SelectListItem() {Value="Raisen                   ", Text="Raisen                      "},
               new SelectListItem() {Value="Rajahmundry              ", Text="Rajahmundry                          "},
               new SelectListItem() {Value="Rajampet                 ", Text="Rajampet                                            "},
               new SelectListItem() {Value="Rajgarh                  ", Text="Rajgarh                          "},
               new SelectListItem() {Value="Nurpur, Himachal Pradesh ", Text="Rajkot                          "},
               new SelectListItem() {Value="Palghat                  ", Text="Rajnandgaon                     "},
               new SelectListItem() {Value="Palwal                   ", Text="Rajsthan                         "},
               new SelectListItem() {Value="Panaji                   ", Text="Ramanathapuram                      "},
               new SelectListItem() {Value="Panchkula                ", Text="Rameshwaram                             "},
               new SelectListItem() {Value="Pandharpur               ", Text="Rampur                          "},
               new SelectListItem() {Value="Panipat                  ", Text="Ranchi                              "},
               new SelectListItem() {Value="Panna                    ", Text="Rangapara                   "},
               new SelectListItem() {Value="Panvel                   ", Text="Ranikhet                            "},
               new SelectListItem() {Value="Pasla, Punjab            ", Text="Rasheed                     "},
               new SelectListItem() {Value="Patan                    ", Text="Ratangarh                   "},
               new SelectListItem() {Value="Pathankot                ", Text="Ratlam                  "},
               new SelectListItem() {Value="Patiala                  ", Text="Ratnagiri                       "},
               new SelectListItem() {Value="Patna                    ", Text="Raurkela                                "},
               new SelectListItem() {Value="Patratu,Jharkhand        ", Text="Ravulapalem                                         "},
               new SelectListItem() {Value="Pimpri Chinchwad         ", Text="Rewa                        "},
               new SelectListItem() {Value="Ponda                    ", Text="Ringawa                             "},
               new SelectListItem() {Value="Porbandar                ", Text="Rishikesh                                   "},
               new SelectListItem() {Value="Port Blair               ", Text="Roorkee                 "},
               new SelectListItem() {Value="Pratapgarh               ", Text="Sagars                  "},
               new SelectListItem() {Value="Puducherry               ", Text="Saharanpur                      "},
               new SelectListItem() {Value="Punalur                  ", Text="Salem                       "},
               new SelectListItem() {Value="Pune                     ", Text="Samastipur                           "},
               new SelectListItem() {Value="Puri                     ", Text="Sanawad                                                 "},
               new SelectListItem() {Value="Pushkar                  ", Text="Sangamner           "},
               new SelectListItem() {Value="Quilon                   ", Text="Sangli                          "},
               new SelectListItem() {Value="Rae Bareli               ", Text="Satara               "},
               new SelectListItem() {Value="Raichur                  ", Text="Sathyamangalam              "},
               new SelectListItem() {Value="Raigarh                  ", Text="Satna                            "},
               new SelectListItem() {Value="Raipur                   ", Text="Sehore                  "},
               new SelectListItem() {Value="Raisen                   ", Text="Seoni                   "},
               new SelectListItem() {Value="Rajahmundry              ", Text="Shajapur                    "},
               new SelectListItem() {Value="Rajampet                 ", Text="Shegaon                 "},
               new SelectListItem() {Value="Rajgarh                  ", Text="Sheopur                 "},
               new SelectListItem() {Value="Shevgaon      ", Text="Shevgaon                    "},
               new SelectListItem() {Value="Shillong      ", Text="Shillong                    "},
               new SelectListItem() {Value="Shimla        ", Text="Shimla                "},
               new SelectListItem() {Value="Shimoga       ", Text="Shimoga                 "},
               new SelectListItem() {Value="Shirala       ", Text="Shirala                 "},
               new SelectListItem() {Value="Shivani       ", Text="Shivani                 "},
               new SelectListItem() {Value="Shivpuri      ", Text="Shivpuri                 "},
               new SelectListItem() {Value="Shoaib        ", Text="Shoaib                  "},
               new SelectListItem() {Value="Sholapur      ", Text="Sholapur                "},
               new SelectListItem() {Value="shrigonda     ", Text="shrigonda                           "},
               new SelectListItem() {Value="shrirampur    ", Text="shrirampur                  "},
               new SelectListItem() {Value="Siddipet      ", Text="Siddipet                    "},
               new SelectListItem() {Value="Sikar         ", Text="Sikar               "},
               new SelectListItem() {Value="Silchar       ", Text="Silchar                     "},
               new SelectListItem() {Value="Siliguri      ", Text="Siliguri                "},
               new SelectListItem() {Value="Silvassa      ", Text="Silvassa                    "},
               new SelectListItem() {Value="Sindhanur     ", Text="Sindhanur                   "},
               new SelectListItem() {Value="Singrauli     ", Text="Singrauli                       "},
               new SelectListItem() {Value="Sirohi        ", Text="Sirohi                                  "},
               new SelectListItem() {Value="Sironj        ", Text="Sironj                      "},
               new SelectListItem() {Value="Sitamarhi     ", Text="Sitamarhi                                   "},
               new SelectListItem() {Value="Sitapur       ", Text="Sitapur                                     "},
               new SelectListItem() {Value="Siwan         ", Text="Siwan                                       "},
               new SelectListItem() {Value="Sonipat       ", Text="Sonipat                 "},
               new SelectListItem() {Value="Sriganganagar ", Text="Sriganganagar                                   "},
               new SelectListItem() {Value="Srikakulam    ", Text="Srikakulam                      "},
               new SelectListItem() {Value="Srinagar      ", Text="Srinagar                             "},
               new SelectListItem() {Value="Surat         ", Text="Surat                               "},
               new SelectListItem() {Value="Suratgarh     ", Text="Suratgarh                                "},
               new SelectListItem() {Value="Surendranagar ", Text="Surendranagar                                    "},
               new SelectListItem() {Value="Tamluk        ", Text="Tamluk                  "},
               new SelectListItem() {Value="Tandur        ", Text="Tandur                          "},
               new SelectListItem() {Value="Tenali        ", Text="Tenali                                  "},
               new SelectListItem() {Value="Thane         ", Text="Thane           "},
               new SelectListItem() {Value="Thanjavur            ", Text="Thanjavur                   "},
               new SelectListItem() {Value="Thathawata           ", Text="Thathawata                          "},
               new SelectListItem() {Value="Thiruvallur          ", Text="Thiruvallur                         "},
               new SelectListItem() {Value="Thiruvananthapuram   ", Text="Thiruvananthapuram                          "},
               new SelectListItem() {Value="Thoothukudi          ", Text="Thoothukudi                 "},
               new SelectListItem() {Value="Thrikkannamangal     ", Text="Thrikkannamangal                        "},
               new SelectListItem() {Value="Thrissur             ", Text="Thrissur                    "},
               new SelectListItem() {Value="Tikamgarh            ", Text="Tikamgarh                       "},
               new SelectListItem() {Value="Tinsukia             ", Text="Tinsukia                    "},
               new SelectListItem() {Value="Tiruchirappalli      ", Text="Tiruchirappalli                          "},
               new SelectListItem() {Value="Tirunelveli          ", Text="Tirunelveli                     "},
               new SelectListItem() {Value="Tirupathi            ", Text="Tirupathi                           "},
               new SelectListItem() {Value="Tirupattur           ", Text="Tirupattur                          "},
               new SelectListItem() {Value="Tirupur              ", Text="Tirupur                                 "},
               new SelectListItem() {Value="Tiruvarur            ", Text="Tiruvarur                       "},
               new SelectListItem() {Value="Tzudikong            ", Text="Tzudikong                           "},
               new SelectListItem() {Value="Udaipur in Rajasthan ", Text="Udaipur in Rajasthan            "},
               new SelectListItem() {Value="Udaipur in Tripura   ", Text="Udaipur in Tripura                      "},
               new SelectListItem() {Value="Udhagamandalam       ", Text="Udhagamandalam                      "},
               new SelectListItem() {Value="Udhampur in Jammu &amp; Kashmir  ", Text="Udhampur in Jammu &amp; Kashmir                 "},
               new SelectListItem() {Value="Udupi                            ", Text="Udupi                               "},
               new SelectListItem() {Value="Ujjain                           ", Text="Ujjain                              "},
               new SelectListItem() {Value="Ulhasnagar                       ", Text="Ulhasnagar                              "},
               new SelectListItem() {Value="Unnao                            ", Text="Unnao                               "},
               new SelectListItem() {Value="Uttarpara in West Bengal         ", Text="Uttarpara in West Bengal             "},
               new SelectListItem() {Value="Vadodara                         ", Text="Vadodara                            "},
               new SelectListItem() {Value="Vallabh Vidhyanagar              ", Text="Vallabh Vidhyanagar                                     "},
               new SelectListItem() {Value="Valsad                           ", Text="Valsad                              "},
               new SelectListItem() {Value="Vandavasi                        ", Text="Vandavasi                               "},
               new SelectListItem() {Value="Vapi                             ", Text="Vapi                                         "},
               new SelectListItem() {Value="Varanasi                         ", Text="Varanasi                                    "},
               new SelectListItem() {Value="Vasai                            ", Text="Vasai                                   "},
               new SelectListItem() {Value="Vasco da Gama, Goa               ", Text="Vasco da Gama, Goa                                   "},
               new SelectListItem() {Value="Vellore                          ", Text="Vellore                              "},
               new SelectListItem() {Value="Vidisha                          ", Text="Vidisha                                  "},
               new SelectListItem() {Value="Vijayawada                       ", Text="Vijayawada                                  "},
               new SelectListItem() {Value="Viluppuram                       ", Text="Viluppuram                                  "},
               new SelectListItem() {Value="Virar                            ", Text="Virar                               "},
               new SelectListItem() {Value="Virudhachalam                    ", Text="Virudhachalam                           "},
               new SelectListItem() {Value="Visakhapatnam                    ", Text="Visakhapatnam                           "},
               new SelectListItem() {Value="Vizianagaram                     ", Text="Vizianagaram                            "},
               new SelectListItem() {Value="Vyara                            ", Text="Vyara                                "},
               new SelectListItem() {Value="Wani                             ", Text="Wani                                    "},
               new SelectListItem() {Value="Warangal                         ", Text="Warangal                                        "},
               new SelectListItem() {Value="Wardha                           ", Text="Wardha                                  "},
               new SelectListItem() {Value="Wayanad                          ", Text="Wayanad                                 "}
               
            };
            return city;
        }



        //public static IEnumerable<SelectListItem> DropdownGender()
        //{
        //    IList<SelectListItem> gender = new List<SelectListItem>
        //    {
        //       new SelectListItem() {Value="Male", Text="Male"},
        //       new SelectListItem() {Value="Female", Text="Female"}
        //    };
        //    return gender;
        //}

        //public static List<FF_Category> Dropdown_Category()
        //{

        //    using (DataContext dc = new DataContext())
        //    {
        //        var Category = dc.FF_Category.ToList();
        //        return Category;

        //        //var Category = dc.FF_Category;

        //        //return string.Join("", Category.Select(s => "<option value=\"" + s.ID + "\">" + s.Category + "));
        //    }

        //}

    }
}