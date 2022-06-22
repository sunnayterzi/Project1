// See https://aka.ms/new-console-template for more information
namespace proje_1{

    class Program{
        static void Main(String [] args){

            

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("***************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(0) Programı Sonlandırmak");
            int select = Convert.ToInt32(Console.ReadLine());

            Phone phone = new Phone();
            while(true){
                switch(select)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        phone.newPerson();
                        Console.WriteLine("Başka bir işlem varsa onu tuşlayınız. Çıkış yapmak için 0'a basınız");
                        select = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        phone.PersonDelete();
                        Console.WriteLine("Başka bir işlem varsa onu tuşlayınız. Çıkış yapmak için 0'a basınız");
                        select = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        phone.PersonUpdate();
                        Console.WriteLine("Başka bir işlem varsa onu tuşlayınız. Çıkış yapmak için 0'a basınız");
                        select = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4: 
                        phone.DisplayPersons();
                        Console.WriteLine("Başka bir işlem varsa onu tuşlayınız. Çıkış yapmak için 0'a basınız");
                        select = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 5:
                        phone.SearchPersons();
                        Console.WriteLine("Başka bir işlem varsa onu tuşlayınız. Çıkış yapmak için 0'a basınız");
                        select = Convert.ToInt32(Console.ReadLine());
                        break;

                }
            }

            
        }
    }

    class Person {
        public string name;
        public string surname;
        public string phone;

        public Person(string name, string surname, string phone){
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }
    }

    class Phone{
        List <Person> persons = new List<Person>();

        public Phone(){

            persons.Add(new Person("sunay","terzi","5456587896"));
            persons.Add(new Person("elif","yilmaz","5367845626"));
            persons.Add(new Person("mehmet","deniz","5387451819"));
            persons.Add(new Person("alper","bilge","5425648287"));
            persons.Add(new Person("seval","keskin","5389651718"));
        }

         public void newPerson()                             
        {

            Console.Write("Lütfen isim giriniz: ");
            String name = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz: ");
            string surname = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz: ");
            string phone = Console.ReadLine();

            persons.Add(new Person(name, surname, phone));
            Console.WriteLine("Kayıt işlemi başarıyla gerçekleştirildi.");
        }

         public void PersonDelete()                             
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string str = Console.ReadLine();

            foreach (var person in persons)
            {
                if (person.name == str || person.surname == str)
                {
                    Console.Write("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n) ", str);
                    string selection = Console.ReadLine();

                    if (selection == "y" || selection == "Y")
                    {
                        persons.Remove(person);
                        Console.WriteLine("Silme işlemi başarılı");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.ReadLine();
                        break;
                    }
                }

                else{
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("Yeniden denemek için      : (2)");
                    int selection2 = Convert.ToInt32(Console.ReadLine());
                    if (selection2==1) {
                        Environment.Exit(0);
                   }

                   else PersonDelete();


                }
            }
        }

        public void PersonUpdate()                             
        {
            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:   ");
            string str = Console.ReadLine();
            int _choice = 1;
            bool IsThere = false;
            foreach (var person in persons)
            {
                if (person.name == str || person.surname == str)
                {
                    Console.WriteLine("Lütfen yeni telefon numarasını giriniz :   ");
                    string newPhone = Console.ReadLine();
                    person.phone = newPhone;
                    Console.WriteLine("Numara başarılı bir şekilde güncellendi");
                    Console.ReadLine();
                    IsThere = true;
                    break;
                }
            }
            if (!IsThere)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.     : ");
                Console.WriteLine(" *Yeniden denemek icin: (1)");
                Console.WriteLine(" Güncellemeyi sonlandırmak için: (2)");
                int selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                {
                    PersonUpdate();
                }
                else if (selection == 2)
                {
                    Environment.Exit(0);
                }
            }
        }

        public void DisplayPersons()                         
        {
            persons.Sort(delegate (Person p1, Person p2) { return p1.name.CompareTo(p2.name); });

            Console.WriteLine("A-Z sıralaması(1)");
            Console.WriteLine("Z-A sıralaması(2)");
            int selection = int.Parse(Console.ReadLine());

            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("*********************************");

            if (selection == 2)
                persons.Reverse();

            foreach (var person in persons)
            {
                Console.WriteLine("isim: {0}", person.name);
                Console.WriteLine("Soyisim: {0}", person.surname);
                Console.WriteLine("Telefon Numarasi: {0}", person.phone);
                Console.WriteLine("-");
            }
            Console.ReadLine();
        }

        public void SearchPersons()                   
        {
            Console.WriteLine("Lütfen aramak istediğiniz kişinin adını veya soyadını giriniz   : ");
            string str = Console.ReadLine();
            bool IsThere = false;

            foreach (var person in persons)
            {
                if (person.name == str || person.surname == str)
                {
                    Console.WriteLine("Isim :   {0}", person.name);
                    Console.WriteLine("Soyisim :   {0}", person.surname);
                    Console.WriteLine("Telefon Numarasi :   {0}", person.phone);
                    Console.WriteLine("-");
                    IsThere = true;
                }
            }
            if (!IsThere)
            {
                Console.WriteLine("Aradığınız kişi bulunamadı!");
                Console.WriteLine(" *Yeniden denemek icin  :(1)");
                Console.WriteLine(" *İşlemi sonlandırmak için: (2)");

                int selection = int.Parse(Console.ReadLine());

                if (selection == 1)
                {
                    SearchPersons();
                }
                else if (selection == 2)
                {
                    Environment.Exit(0);
                }
            }
        }



    }

}
