using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVizev2.Models
{
    public class StatikVeritaban
    {
        private static List<Novel> _novelListesi ;  // Film Listesi
        private static List<Category> _categoryList; // kategori Listesi
        private static List<Comment> _yorumListesi; // yorum Listesi

        static StatikVeritaban()
        {
            // Category Listesine atama gerçekleştirmekteyiz
            _categoryList = new List<Category>()
            {
                new Category(){id=1, Name="Aksiyon"},
                 new Category(){id=2, Name="Macera"},
                  new Category(){id=3, Name="Korku"},
                   new Category(){id=4,Name="Komedi"},
                   new Category(){id=5,Name="Dram"}
            };

            // Novel Listesine atama gerçekleştirmekteyiz
            _novelListesi = new List<Novel>()
            {
                new Novel(){id=1,Name="Stellar Transformation",Headliner="I Eat Tomatoes", translator="Darkcack",Description="In a galaxy far away, there is a kid without innate ability to practice internal techniques. So, in order to gain the respect of his father, he resolutely chooses to follow the more difficult and painful path of practicing external techniques. As the years go by, he grows up, but what really changes his life is a mysterious meteoric crystal stone – the Meteoric Tear.",Year=1989,categoryId=1,category=_categoryList[0]},
                new Novel(){id=2,Name="True Martial World",Headliner="Cocooned Cow", translator="Qidian",Description="Yi Yun is the main protagonist of the novel True Martial World. Formerly a mortal from modern Earth that had unwittingly stumbled upon a Mysterious Card and was transported to the Tian Yuan World of cultivators and martial arts.",Year=1984,categoryId=2,category=_categoryList[1]},
                new Novel(){id=3,Name="Emperor’s Domination",Headliner="Yanbi Xiaosheng", translator="ImmortalEmperorBao",Description=" Ten million years ago, Li Qiye planted a simple water bamboo into the ground.Eight million years ago, Li Qiye had a koi fish pet.Five million years ago, Li Qiye cared for a little girl....In the present day, Li Qiye woke up from his slumber; the water bamboo reached the apex of cultivation; the koi fish became a Golden Dragon; the little girl became the Nine Worlds’ Immortal Empress.",Year=1997,categoryId=3,category=_categoryList[2]},
                new Novel(){id=4,Name="Coiling Dragon",Headliner="I Eat Tomatoes", translator="Qidian",Description="Empires rise and fall on the Yulan Continent. Saints, immortal beings of unimaginable power, battle using spells and swords, leaving swathes of destruction in their wake. Magical beasts rule the mountains, where the brave – or the foolish – go to test their strength. Even the mighty can fall, feasted on by those stronger. The strong live like royalty; the weak strive to survive another day.",Year=1986,categoryId=4,category=_categoryList[3]},
                new Novel(){id=5,Name="Sovereign of the Three Realms",Headliner="Plow Days", translator="etvolare",Description="Jiang Chen, son of the Celestial Emperor, unexpectedly reincarnated into the body of a despised young noble, thus embarking on the path of the underdog trouncing all comers. No one has the right to call himself a genius in front of Jiang Chen, as no one has a better understanding of the heavens than the son of the Celestial Emperor. ",Year=1994,categoryId=5,category=_categoryList[4]},


            };

            // Yorum Listesine atama gerçekleştirmekteyiz
            _yorumListesi = new List<Comment>()
            {
                new Comment(){id=1, yorum="Bu Stellar Transformation novel'a ilk yorumum",Yorumİsmi="Mert Aktaş",Novelid=1 },
                new Comment(){id=2, yorum="Bu True Martial World ilk yorumum",Yorumİsmi="Mert Aktaş",Novelid=2 },
                new Comment(){id=3, yorum="Bu Emperor’s Dominatio novel'a ilk yorumum",Yorumİsmi="Mert Aktaş",Novelid=3 },
                new Comment(){id=4, yorum="Bu Coiling Dragon novel'a ilk yorumum",Yorumİsmi="Mert Aktaş",Novelid=4 },
                new Comment(){id=5, yorum="Bu Sovereign of the Three Realms novel'a ilk yorumum",Yorumİsmi="Mert Aktaş",Novelid=5 },
            };

            //her kategoriye filmleri yukle
            foreach (var cat in _categoryList)
            {
                foreach (var nov in _novelListesi)
                {
                    if (cat.id == nov.category.id)
                    {
                        cat.novels.Add(nov);
                    }
                }
            }

            // her filme yorumları yukle
            foreach (var nov in _novelListesi)
            {
                foreach (var com in _yorumListesi)
                {
                    if (nov.id == com.Novelid)
                    {
                        nov.Comment.Add(com);
                    }
                }
            }


        }

        public static void YorumEkle(Comment comment)
        {
            comment.id = (_yorumListesi[_yorumListesi.Count - 1].id) + 1;  // Ekli Olan En Yüksek id'ye 1 ekleme 
            _yorumListesi.Add(comment);
            foreach (var item in _novelListesi)
            {
                if (comment.Novelid == item.id)
                {
                    item.Comment.Add(comment);
                }

            }
            _yorumListesi.Add(comment);
        }

        public static void YorumSil(int commentid)
        {
            Comment com = null;
            foreach (var item in _yorumListesi)
            {
                if (item.id == commentid)
                {
                    com = item;
                }
            }

            _yorumListesi.Remove(com);

            foreach (var item in _novelListesi)
            {
                if (com.Novelid == item.id)
                {
                    item.Comment.Remove(com);
                }

            }
        }

        public static int YorumlaBul(int commentid)
        {
            int novelid = 0;
            foreach (var item in _yorumListesi)
            {
                if (commentid == item.id)
                {
                    novelid = item.Novelid;
                }


            }
            return novelid;
        }
        public static string KategoriBul(int id)
        {
            id--;
            return _categoryList[id].Name.ToString();
        }

        public static List<Category> KategoriListele
        {
            get { return _categoryList; }
        }

        public static void KategoriEkle(Category category)
        {

            category.id = (_categoryList[_categoryList.Count - 1].id) + 1;  // Ekli Olan En Yüksek id'ye 1 ekleme 



            _categoryList.Add(category);
        }

        public static void KategoriSil(int categoryid)
        {
            Category kategori = null;
            foreach (var item in _categoryList)
            {
                if (item.id == categoryid)
                {
                    kategori = item;
                }
            }
            _categoryList.Remove(kategori);
        }

        public static List<Novel> KategoriDetay(int kategoriid)
        {
            List<Novel> _filmList = null;

            foreach (var item in _categoryList)
            {
                if (item.id == kategoriid)
                {
                    return item.novels;
                }
            }
            return _filmList;
        }


        public static List<Novel> NovelListele
        {
            get { return _novelListesi; }
        }


        public static void NovelEkle(Novel novel)
        {
            foreach (var cat in _categoryList)
            {
                if (novel.categoryId == cat.id)
                {
                    novel.category = cat;
                }
            }
            if (novel.id == 0)
            {
                novel.id = (_novelListesi[_novelListesi.Count - 1].id) + 1;

            }




            _novelListesi.Add(novel);

            //kategorilerin içine o novelı ekleme
            foreach (var item in _categoryList)
            {
                if (item.id == novel.category.id)
                {
                    item.novels.Add(novel);
                }
            }


        }


        public static void NovelSil(int novelid)
        {
            Novel novel = null;
            foreach (var item in _novelListesi)
            {
                if (item.id == novelid)
                {
                    novel = item;
                }
            }
            foreach (var tyy in _categoryList)
            {
                tyy.novels.Remove(novel);
            }
            _novelListesi.Remove(novel);
        }

        public static void NovelGuncelle(Novel novel)
        {
            int id = novel.id;
            StatikVeritaban.NovelSil(id);
            StatikVeritaban.NovelEkle(novel);


        }
        public static Novel DetayNovel(int novelid)
        {
            Novel novel= null;
            foreach (var item in _novelListesi)
            {
                if (item.id == novelid)
                {
                    novel = item;
                }
            }
            return novel;
        }


    }
}