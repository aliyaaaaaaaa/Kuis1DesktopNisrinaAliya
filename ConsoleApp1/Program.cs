using System;
using System.Collections.Generic;
using System.Linq;
using Kuis1;

class Program
{
    static List<Product> products = new List<Product>
    {
        new Product("Laptop Asus", 20000000m, 10),
        new Product("Laptop Hp", 22000000m, 11),
        new Product("Laptop Acer", 25000000m, 12),
        new Product("Smartphone Asus", 2000000m, 20),
        new Product("Smartphone Xiaomi", 4000000m, 21),
        new Product("Smartphone Samsung", 6000000m, 22),
        new Product("Headphones Asus", 300000m, 15),
        new Product("Headphones Xiaomi", 350000m, 16),
        new Product("Headphones Sennheiser", 370000m, 17),
        new Product("Keyboard MSI", 400000m, 25),
        new Product("Keyboard Hp", 450000m, 26),
        new Product("Keyboard Asus", 470000m, 27),
        new Product("Mouse Asus", 100000m, 30),
        new Product("Mouse Xiaomi", 120000m, 31),
        new Product("Mouse Hp", 150000m, 32)
    };

    static User admin = new User("admin", "1234");

    static void Main()
    {
        Console.WriteLine("Selamat datang di Toko Elektonik Aliya!");
        Console.WriteLine("Nama : Nisrina Aliya Hana");
        Console.WriteLine("NPM : 2120101737");
        Console.WriteLine("Kelas : III RPLK");
        Console.WriteLine("~~~~~~~~~~~~~~~~~ KUIS 1 ~~~~~~~~~~~~~~");
        
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (admin.Login(username, password))
        {
            Console.WriteLine("Login sukses!\n");
            int choice = 0;
            do
            {
                Console.WriteLine("1. Sort Produk dengan Stock\n2. Tambah Produk\n3. Hapus Produk\n4. Cari Produk\n5. Byebye");
                Console.Write("Pilih Nomor: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SortProduk();
                        break;
                    case 2:
                        TambahProduk();
                        break;
                    case 3:
                        HapusProduk();
                        break;
                    case 4:
                        CariProduk();
                        break;
                    case 5:
                        Console.WriteLine("Bye-bye!...");
                        break;
                    default:
                        Console.WriteLine("Pilih angka 1-5! Silakan coba lagi.");
                        break;
                }
            } while (choice != 5);
        }
        else
        {
            Console.WriteLine("Login gagal. Silakan coba lagi.");
        }
    }


    static void TambahProduk()
    {
        Console.Write("Nama Produk: ");
        string name = Console.ReadLine();
        Console.Write("Harga: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Harga yang Anda masukkan tidak valid.");
            return;
        }
        Console.Write("Stok tambahan: ");
        if (!int.TryParse(Console.ReadLine(), out int additionalStock))
        {
            Console.WriteLine("Stok yang Anda masukkan tidak valid.");
            return;
        }

        var product = products.FirstOrDefault(p => p.Name == name);
        if (product != null)
        {
            product.Stock += additionalStock;
            Console.WriteLine("Stok berhasil ditambahkan!");
        }
        else
        {
            Console.Write("Produk tidak ada. Apakah Anda ingin menambahkannya? (Y/N): ");
            if (Console.ReadLine().Trim().ToUpper() == "Y")
            {
                products.Add(new Product(name, price, additionalStock));
                Console.WriteLine("Produk baru berhasil ditambahkan!");
            }
            else
            {
                Console.WriteLine("Operasi ditambahkan dibatalkan.");
            }
        }
    }

    static void HapusProduk()
    {
        Console.Write("Nama Produk: ");
        string name = Console.ReadLine();
        var product = products.FirstOrDefault(p => p.Name == name);
        if (product != null)
        {
            Console.Write("Stok untuk dikurangi: ");
            int decreaseStock = int.Parse(Console.ReadLine());
            if (decreaseStock > product.Stock)
            {
                Console.WriteLine("Stok yang akan dikurangi melebihi stok produk.");
                Console.Write("Apakah Anda ingin menghapus produk ini? (Y/N): ");
                if (Console.ReadLine().Trim().ToUpper() == "Y")
                {
                    products.Remove(product);
                    Console.WriteLine("Produk berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("Operasi penghapusan dibatalkan.");
                }
            }
            else
            {
                product.Stock -= decreaseStock;
                Console.WriteLine("Stok berhasil dikurangi!");
            }
        }
        else
        {
            Console.WriteLine("Produk tidak ditemukan!");
        }
    }

    static void CariProduk()
    {
        Console.Write("Nama Produk: ");
        string name = Console.ReadLine();
        Console.Write("Harga Minimum: ");
        decimal minPrice = decimal.Parse(Console.ReadLine());
        Console.Write("Harga Maximum: ");
        decimal maxPrice = decimal.Parse(Console.ReadLine());

        var filteredProducts = products.Where(p => p.Name.Contains(name) && p.Price >= minPrice && p.Price <= maxPrice).ToList();

        if (filteredProducts.Any())
        {
            Console.WriteLine("Produk:");
            foreach (var p in filteredProducts)
            {
                Console.WriteLine($"Nama: {p.Name}, Harga: {p.Price}, Stok: {p.Stock}");
            }
        }
        else
        {
            Console.WriteLine("Produk Tidak Ada!");
        }
    }

    static void SortProduk()
    {
        Console.Write("Urutkan stok secara (A)scending atau (D)escending? ");
        char sortOption = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();  // Move to the next line

        List<Product> sortedProducts;

        if (sortOption == 'A')
        {
            sortedProducts = products.OrderBy(p => p.Stock).ToList();
        }
        else if (sortOption == 'D')
        {
            sortedProducts = products.OrderByDescending(p => p.Stock).ToList();
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid, tidak ada pengurutan yang dilakukan.");
            return; // Exit the function if the input is not valid
        }

        Console.WriteLine("Produk diurutkan berdasarkan stok:");
        foreach (var p in sortedProducts)
        {
            Console.WriteLine($"Nama: {p.Name}, Harga: {p.Price}, Stok: {p.Stock}");
        }
    }
}
