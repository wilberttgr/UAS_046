using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_046
{
    class Node
    {
        public int id_obat, dosis, harga;
        public string nama;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        //Method untuk menambahkan sebuah node ke dalam list

        public void addNode()
        {
            int id, hrga, dsis;
            string nm;
            Console.WriteLine("\nMasukkan id Obat: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan nama Obat: ");
            nm = Console.ReadLine();
            Console.WriteLine("\nMasukkan dosis Obat ");
            dsis = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan harga Obat: ");
            hrga = Convert.ToInt32(Console.ReadLine());

            Node nodeBaru = new Node();
            nodeBaru.id_obat = id;
            nodeBaru.nama = nm;
            nodeBaru.dosis = dsis;
            nodeBaru.harga = hrga;

            //Node ditambahkan sebagai node pertama 
            if (START == null || id <= START.id_obat)
            {
                if ((START != null) && (id == START.id_obat))
                {
                    Console.WriteLine("\nNomer obat sama tidak diizinkan");
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            //Menemukan lokasi node baru didalam list
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.id_obat))
            {
                if (id == current.id_obat)
                {
                    Console.WriteLine("\nNomer obat sama tidak diizinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            //Node baru akan ditempatkan di antara previous dan current
            nodeBaru.next = current;
            previous.next = nodeBaru;
        }
        //Method untuk menghapus node tertentu didalam list
        public bool addNode(int id)
        {
            Node previous, current;
            previous = current = null;
            //check apakah node yang dimaksud ada didalam list atau tidak
            if (Search(id, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        //Method untuk meng-check apakah node yang dimaksud ada di dalam list atau tidak
        public bool Search(int dsis, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (dsis != current.dosis))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong. \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah : \n");
                Node currentnode;
                for (currentnode = START; currentnode != null; currentnode = currentnode.next)
                    Console.Write(currentnode.id_obat + " " + currentnode.nama + " " + currentnode.dosis + " " + currentnode.harga);
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        class Program
        {
            static void Main(string[] args)
            {
                List obj = new List();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Add data obat");
                        Console.WriteLine("2. Delete data obat");
                        Console.WriteLine("3. View data obat");
                        Console.WriteLine("4. Search data obat");
                        Console.WriteLine("5. Exit");
                        Console.Write("\nMasukkan Pilihan Anda (1-5): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nList Kosong");
                                        break;
                                    }
                                    Console.Write("\nMasukkan dosis obat yang akan dihapus: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.addNode(id) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                        Console.WriteLine("Data dengan nomor obat " + id + " dihapus ");
                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList Kosong !");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan dosis obat yang akan dicari: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nData ketemu");
                                        Console.WriteLine("\nId Obat: " + current.id_obat);
                                        Console.WriteLine("\nNama Obat: " + current.nama);
                                        Console.WriteLine("\nDosis Obat: " + current.dosis);
                                        Console.WriteLine("\nHarga Obat: " + current.harga);
                                    }
                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nPilihan tidak valid");
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nCheck nilai yang anda masukkan. ");
                    }
                }
            }
        }
    }
}
//2. Singly Linked List, karena implementasi yang sederhana dan Pada singly linked list, insertion atau deletion dapat dilakukan dengan cepat pada ujung atau awal dari list.
//3. Perbedaan array dan linked list adalah :
// - Linked list hanya menyimpan data yang diperlukan saja
// - Linked list dapat dilakukan dengan cepat pada ujung atau awal dari list sedangkan array harus di geser satu persatu elemen.
//4. Enqueue dan Dequeue
//5. a. 41 dan 74
//   b. inorder
//      16,25,41,42,46,53,55,60,62,63,64,65,70,74
