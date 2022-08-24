using MoviesWebAPI.Data.Models;

namespace MoviesWebAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //feltoltom a Users tablat ha netalan ures lenne
                if (context != null && !context.Users.Any())
                {
                    context.Users.AddRange(
                        new Users()
                        {
                            UserName = "testuser1",
                            Password = "123456",
                            Email = "testemail@gmail.com"
                        },
                        new Users()
                        {
                            UserName = "testuser2",
                            Password = "23456789",
                            Email = "testuser2email@gmail.com"
                        },
                        new Users()
                        {
                            UserName = "testuser3",
                            Password = "testuser3",
                            FirstName = "Pityi",
                            LastName = "Palko",
                            Gender = "Male",
                            Email = "testuser3@gmail.com"
                        }
                   );

                    context.SaveChanges();
                }

                //feltoltom a Movies ,Genres es MoviesGenres tablakat ha netalan uresek
                if(context != null && !context.Movies.Any() && !context.Genres.Any())
                {
                    uploadMoviesGenresTable(context);
                    context.SaveChanges();
                }
            }
        }

        private static void uploadMoviesGenresTable(AppDbContext context)
        {
            var genreList = new List<Genres> { 
                new Genres
                {
                    GenreName = "Action"
                },
                new Genres
                {
                    GenreName = "Adult"
                },
                new Genres
                {
                    GenreName = "Adventure"
                },
                new Genres
                {
                    GenreName = "Animation"
                },
                new Genres
                {
                    GenreName = "Biography"
                },
                new Genres
                {
                    GenreName = "Comedy"
                },
                new Genres
                {
                    GenreName = "Crime"
                },
                new Genres
                {
                    GenreName = "Documentary"
                },
                new Genres
                {
                    GenreName = "Drama"
                },
                new Genres
                {
                    GenreName = "Family"
                },
                new Genres
                {
                    GenreName = "Fantasy"
                },
                new Genres
                {
                    GenreName = "Film Noir"
                },
                new Genres
                {
                    GenreName = "Game Show"
                },
                new Genres
                {
                    GenreName = "History"
                },
                new Genres
                {
                    GenreName = "Horror"
                },
                new Genres
                {
                    GenreName = "Musical"
                },
                new Genres
                {
                    GenreName = "Music"
                },
                new Genres
                {
                    GenreName = "Mystery"
                },
                new Genres
                {
                    GenreName = "News"
                },
                new Genres
                {
                    GenreName = "Reality-Tv"
                },
                new Genres
                {
                    GenreName = "Romance"
                },
                new Genres
                {
                    GenreName = "Sci-Fi"
                },
                new Genres
                {
                    GenreName = "Short"
                },
                new Genres
                {
                    GenreName = "Sport"
                },
                new Genres
                {
                    GenreName = "Talk-Show"
                },
                new Genres
                {
                    GenreName = "Thriller"
                },
                new Genres
                {
                    GenreName = "War"
                },
                new Genres
                {
                    GenreName = "Western"
                }
            };

            context.Movies.AddRange(
                new Movies
                {
                    Title = "Iron Man",
                    ReleaseDate = new DateTime(2008, 4, 30),
                    RunTime = 126,
                    Rating = 7.9,
                    NumberOfRatings = 1020764,
                    Description = "2008's Iron Man tells the story of Tony Stark, a billionaire industrialist and genius inventor who is kidnapped and forced to build a devastating weapon. Instead, using his intelligence and ingenuity, Tony builds a high-tech suit of armor and escapes captivity.",
                    Genres = new List<Genres> { genreList[0], genreList[2], genreList[21]}
                },
                new Movies
                {
                    Title = "The Incredible Hulk",
                    ReleaseDate = new DateTime(2008, 6, 13),
                    RunTime = 112,
                    Rating = 6.7,
                    NumberOfRatings = 473922,
                    Description = "In this new beginning, scientist Bruce Banner desperately hunts for a cure to the gamma radiation that poisoned his cells and unleashes the unbridled force of rage within him: Hulk. Living in the shadows--cut off from a life he knew and the woman he loves, Betty Ross--Banner struggles to avoid the obsessive pursuit of his nemesis, General Thunderbolt Ross and the military machinery that seeks to capture him and brutally exploit his power. As all three grapple with the secrets that led to Hulk's creation, they are confronted with a monstrous new adversary known as the Abomination, whose destructive strength exceeds even Hulk's own. One scientist must make an agonizing final choice: accept a peaceful life as Bruce Banner or find heroism in the creature he holds inside--The Incredible Hulk.",
                    Genres= new List<Genres> { genreList[0], genreList[2], genreList[21] }
                }, 
                new Movies
                {
                    Title = "Iron Man 2",
                    ReleaseDate = new DateTime(2010, 5, 7),
                    RunTime = 125,
                    Rating = 7,
                    NumberOfRatings = 787978,
                    Description = "With the world now aware that he is Iron Man, billionaire inventor Tony Stark faces pressure from all sides to share his technology with the military. He is reluctant to divulge the secrets of his armored suit, fearing the information will fall into the wrong hands. With Pepper Potts and 'Rhodey' Rhodes by his side, Tony must forge new alliances and confront a powerful new enemy.",
                    Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                },
                 new Movies
                 {
                     Title = "Thor",
                     ReleaseDate = new DateTime(2011, 5, 6),
                     RunTime = 114,
                     Rating = 7,
                     NumberOfRatings = 812742,
                     Description = "As the son of Odin, king of the Norse gods, Thor will soon inherit the throne of Asgard from his aging father. However, on the day that he is to be crowned, Thor reacts with brutality when the gods' enemies, the Frost Giants, enter the palace in violation of their treaty. As punishment, Odin banishes Thor to Earth. While Loki, Thor's brother, plots mischief in Asgard, Thor, now stripped of his powers, faces his greatest threat.",
                     Genres = new List<Genres> { genreList[0],genreList[2],genreList[10]}
                 },
                 new Movies
                 {
                     Title = "Captain America: The First Avenge",
                     ReleaseDate = new DateTime(2011, 7, 22),
                     RunTime = 124,
                     Rating = 6.9,
                     NumberOfRatings = 814199,
                     Description = "Marvel's Captain America: The First Avenger focuses on the early days of the Marvel Universe when Steve Rogers volunteers to participate in an experimental program that turns him into the Super Soldier known as Captain America.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Iron Man 3",
                     ReleaseDate = new DateTime(2013, 5, 3),
                     RunTime = 130,
                     Rating = 7.2,
                     NumberOfRatings = 820502,
                     Description = "Marvel's Iron Man 3 pits brash-but-brilliant industrialist Tony Stark/Iron Man against an enemy whose reach knows no bounds. When Stark finds his personal world destroyed at his enemy's hands, he embarks on a harrowing quest to find those responsible. This journey, at every turn, will test his mettle. With his back against the wall, Stark is left to survive by his own devices, relying on his ingenuity and instincts to protect those closest to him. As he fights his way back, Stark discovers the answer to the question that has secretly haunted him: does the man make the suit or does the suit make the man?",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Thor: The Dark World",
                     ReleaseDate = new DateTime(2013, 11, 8),
                     RunTime = 112,
                     Rating = 6.8,
                     NumberOfRatings = 653834,
                     Description = "In the aftermath of Marvel's 'Thor' and Marvel's The Avengers, Thor fights to restore order across the cosmos...but an ancient race led by the vengeful Malekith returns to plunge the universe back into darkness. Faced with an enemy that even Odin and Asgard cannot withstand, Thor must embark on his most perilous and personal journey yet, one that will reunite him with Jane Foster and force him to sacrifice everything to save us all.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[10] }
                 },
                 new Movies
                 {
                     Title = "Captain America: The Winter Soldier",
                     ReleaseDate = new DateTime(2014, 4, 4),
                     RunTime = 136,
                     Rating = 7.8,
                     NumberOfRatings = 810776,
                     Description = "After the cataclysmic events in New York with The Avengers, Marvel's Captain America: The Winter Soldier, finds Steve Rogers, aka Captain America, living quietly in Washington, D.C. and trying to adjust to the modern world. But when a S.H.I.E.L.D. colleague comes under attack, Steve becomes embroiled in a web of intrigue that threatens to put the world at risk. Joining forces with the Black Widow, Captain America struggles to expose the ever-widening conspiracy while fighting off professional assassins sent to silence him at every turn. When the full scope of the villainous plot is revealed, Captain America and the Black Widow enlist the help of a new ally, the Falcon. However, they soon find themselves up against an unexpected and formidable enemy--the Winter Soldier.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Guardians of the Galaxy",
                     ReleaseDate = new DateTime(2014, 8, 1),
                     RunTime = 121,
                     Rating = 8.1,
                     NumberOfRatings = 1133058,
                     Description = "An action-packed, epic space adventure, Marvel's Guardians of the Galaxy,expands the Marvel Cinematic Universe into the cosmos, where brash adventurer Peter Quill finds himself the object of an unrelenting bounty hunt after stealing a mysterious orb coveted by Ronan, a powerful villain with ambitions that threaten the entire universe. To evade the ever-persistent Ronan, Quill is forced into an uneasy truce with a quartet of disparate misfits--Rocket, a gun-toting raccoon; Groot, a tree-like humanoid; the deadly and enigmatic Gamora; and the revenge-driven Drax the Destroyer. But when Quill discovers the true power of the orb and the menace it poses to the cosmos, he must do his best to rally his ragtag rivals for a last, desperate stand--with the galaxy's fate in the balance.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[5] }
                 },
                 new Movies
                 {
                     Title = "Avengers: Age of Ultron",
                     ReleaseDate = new DateTime(2015, 5, 1),
                     RunTime = 141,
                     Rating = 7.3,
                     NumberOfRatings = 826558,
                     Description = "Marvel Studios presents Avengers: Age of Ultron, the epic follow-up to the biggest Super Hero movie of all time. When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes, including Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, along with support from Nick Fury and Maria Hill are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to the Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Ant-Man",
                     ReleaseDate = new DateTime(2015, 7, 17),
                     RunTime = 117,
                     Rating = 7.3,
                     NumberOfRatings = 636902,
                     Description = "The next evolution of the Marvel Cinematic Universe brings a founding member of The Avengers to the big screen for the first time with Marvel Studios' 'Ant - Man'. Armed with the astonishing ability to shrink in scale but increase in strength, master thief Scott Lang must embrace his inner-hero and help his mentor, Doctor Hank Pym, protect the secret behind his spectacular Ant-Man suit from a new generation of towering threats. Against seemingly insurmountable obstacles, Pym and Lang must plan and pull off a heist that will save the world.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[5] }
                 },
                 new Movies
                 {
                     Title = "Captain America: Civil War",
                     ReleaseDate = new DateTime(2016, 5, 6),
                     RunTime = 147,
                     Rating = 7.8,
                     NumberOfRatings = 747324,
                     Description = "Marvel’s Captain America: Civil War finds Steve Rogers leading the newly formed team of Avengers in their continued efforts to safeguard humanity. But after another incident involving the Avengers results in collateral damage, political pressure mounts to install a system of accountability, headed by a governing body to oversee and direct the team. The new status quo fractures the Avengers, resulting in two camps—one led by Steve Rogers and his desire for the Avengers to remain free to defend humanity without government interference, and the other following Tony Stark’s surprising decision to support government oversight and accountability.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Guardians of the Galaxy Vol. 2",
                     ReleaseDate = new DateTime(2017, 5, 5),
                     RunTime = 136,
                     Rating = 7.6,
                     NumberOfRatings = 644186,
                     Description = "Set to the backdrop of 'Awesome Mixtape #2', Marvel's Guardians of the Galaxy Vol. 2 continues the team's adventures as they traverse the outer reaches of the cosmos. The Guardians must fight to keep their newfound family together as they unravel the mysteries of Peter Quill's true parentage. Old foes become new allies and fan-favorite characters from the classic comics will come to our heroes' aid as the Marvel Cinematic Universe continues to expand.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[5] }
                 },
                 new Movies
                 {
                     Title = "Thor: Ragnarok",
                     ReleaseDate = new DateTime(2017, 11, 3),
                     RunTime = 130,
                     Rating = 7.9,
                     NumberOfRatings = 689746,
                     Description = "Thor's world is about to explode in Marvel's Thor: Ragnarok. His devious brother, Loki, has taken over Asgard, the powerful Hela has emerged to steal the throne for herself and Thor is imprisoned on the other side of the universe. To escape captivity and save his home from imminent destruction, Thor must first win a deadly alien contest by defeating his former ally and fellow Avenger... The Incredible Hulk!",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[5] }
                 },
                 new Movies
                 {
                     Title = "Black Panther",
                     ReleaseDate = new DateTime(2018, 2, 16),
                     RunTime = 134,
                     Rating = 7.3,
                     NumberOfRatings = 715020,
                     Description = "Marvel Studios’ “Black Panther” follows T’Challa who, after the death of his father, the King of Wakanda, returns home to the isolated, technologically advanced African nation to succeed to the throne and take his rightful place as king. But when a powerful old enemy reappears, T’Challa’s mettle as king—and Black Panther—is tested when he is drawn into a formidable conflict that puts the fate of Wakanda and the entire world at risk. Faced with treachery and danger, the young king must rally his allies and release the full power of Black Panther to defeat his foes and secure the safety of his people and their way of life.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "The Avengers",
                     ReleaseDate = new DateTime(2012, 5, 4),
                     RunTime = 143,
                     Rating = 8.1,
                     NumberOfRatings = 1347665,
                     Description = "Marvel Studios presents in association with Paramount Pictures 'Marvel's The Avengers'--the super hero team up of a lifetime, featuring iconic Marvel super heroes Iron Man, the Incredible Hulk, Thor, Captain America, Hawkeye and Black Widow. When an unexpected enemy emerges that threatens global safety and security, Nick Fury, Director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Avengers: Infinity War",
                     ReleaseDate = new DateTime(2018, 4, 27),
                     RunTime = 149,
                     Rating = 8.5,
                     NumberOfRatings = 1000163,
                     Description = "An unprecedented cinematic journey ten years in the making and spanning the entire Marvel Cinematic Universe, Marvel Studios' Avengers: Infinity War brings to the screen the ultimate, deadliest showdown of all time. As the Avengers and their allies have continued to protect the world from threats too large for any one hero to handle, a new danger has emerged from the cosmic shadows: Thanos. A despot of intergalactic infamy, his goal is to collect all six Infinity Stones, artifacts of unimaginable power, and use them to inflict his twisted will on all of reality. Everything the Avengers have fought for has led up to this moment - the fate of Earth and existence itself has never been more uncertain.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Ant-Man and the Wasp",
                     ReleaseDate = new DateTime(2018, 7, 6),
                     RunTime = 118,
                     Rating = 7,
                     NumberOfRatings = 374211,
                     Description = "From the Marvel Cinematic Universe comes a new chapter featuring heroes with the astonishing ability to shrink: “Ant-Man and The Wasp.” In the aftermath of “Captain America: Civil War,” Scott Lang (Paul Rudd) grapples with the consequences of his choices as both a Super Hero and a father. As he struggles to rebalance his home life with his responsibilities as Ant-Man, he’s confronted by Hope van Dyne (Evangeline Lilly) and Dr. Hank Pym (Michael Douglas) with an urgent new mission. Scott must once again put on the suit and learn to fight alongside The Wasp as the team works together to uncover secrets from their past.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[5] }
                 },
                 new Movies
                 {
                     Title = "Avengers: Endgame",
                     ReleaseDate = new DateTime(2019, 4, 26),
                     RunTime = 181,
                     Rating = 8.4,
                     NumberOfRatings = 1035293,
                     Description = "The grave course of events set in motion by Thanos that wiped out half the universe and fractured the Avengers ranks compels the remaining Avengers to take one final stand in Marvel Studios' grand conclusion to twenty-two films, Avengers: Endgame.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[8] }
                 },
                 new Movies
                 {
                     Title = "Doctor Strange",
                     ReleaseDate = new DateTime(2016, 11, 4),
                     RunTime = 115,
                     Rating = 7.5,
                     NumberOfRatings = 687852,
                     Description = "From Marvel Studios comes “Doctor Strange,” the story of world-famous neurosurgeon Dr. Stephen Strange whose life changes forever after a horrific car accident robs him of the use of his hands. When traditional medicine fails him, he is forced to look for healing, and hope, in an unlikely place—a mysterious enclave known as Kamar-Taj. Before long Strange—armed with newly acquired magical powers—is forced to choose whether to return to his life of fortune and status or leave it all behind to defend the world as the most powerful sorcerer in existence.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[10] }
                 },
                 new Movies
                 {
                     Title = "Spider-Man: Far From Home",
                     ReleaseDate = new DateTime(2019, 7, 2),
                     RunTime = 129,
                     Rating = 7.4,
                     NumberOfRatings = 454954,
                     Description = "Following the events of Avengers: Endgame, Spider-Man must step up to take on new threats in a world that has changed forever.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[21] }
                 },
                 new Movies
                 {
                     Title = "Spider-Man: No Way Home",
                     ReleaseDate = new DateTime(2021, 12, 17),
                     RunTime = 148,
                     Rating = 8.5,
                     NumberOfRatings = 573819,
                     Description = "For the first time in the cinematic history of Spider-Man, our friendly neighborhood hero's identity is revealed, bringing his Super Hero responsibilities into conflict with his normal life and putting those he cares about most at risk. When he enlists Doctor Strange's help to restore his secret, the spell tears a hole in their world, releasing the most powerful villains who’ve ever fought a Spider-Man in any universe. Now, Peter will have to overcome his greatest challenge yet, which will not only forever alter his own future but the future of the Multiverse.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[10] }
                 },
                 new Movies
                 {
                     Title = "Zack Snyder's Justice League",
                     ReleaseDate = new DateTime(2021, 3, 18),
                     RunTime = 241,
                     Rating = 8.1,
                     NumberOfRatings = 370464,
                     Description = "In Zack Snyder's Justice League, determined to ensure Superman's ultimate sacrifice was not in vain, Bruce Wayne aligns forces with Diana Prince with plans to recruit a team of metahumans to protect the world from an approaching threat of catastrophic proportions. The task proves more difficult than Bruce imagined, as each of the recruits must face the demons of their own pasts to transcend that which has held them back, allowing them to come together, finally forming an unprecedented league of heroes. Now united; Batman, Wonder Woman, Aquaman, Cyborg and the Flash must save the planet from Steppenwolf, DeSaad and Darkseid and their dreadful intentions.",
                     Genres = new List<Genres> { genreList[0], genreList[2], genreList[10] }
                 },
                 new Movies
                 {
                     Title = "Batman Begins",
                     ReleaseDate = new DateTime(2005, 6, 15),
                     RunTime = 140,
                     Rating = 8.3,
                     NumberOfRatings = 1417005,
                     Description = "After training with his mentor, Batman begins his fight to free crime-ridden Gotham City from corruption. When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil.",
                     Genres = new List<Genres> { genreList[0], genreList[6], genreList[8] }
                 },
                  new Movies
                  {
                      Title = "The Dark Knight",
                      ReleaseDate = new DateTime(2008, 7, 18),
                      RunTime = 152,
                      Rating = 9.1,
                      NumberOfRatings = 2535797,
                      Description = "A gang of criminals robs a Gotham City mob bank; the Joker manipulates them into murdering each other for a higher share until only he remains and escapes with the money. Batman, District Attorney Harvey Dent and Lieutenant Jim Gordon form an alliance to rid Gotham of organized crime.",
                      Genres = new List<Genres> { genreList[0], genreList[6], genreList[8] }
                  }
            );
        }
    }
}
