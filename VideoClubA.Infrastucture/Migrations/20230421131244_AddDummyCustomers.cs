using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClubA.Infrastucture.Migrations
{
    public partial class AddDummyCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add seed data for the Customers table
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "IsAdmin" },
                values: new object[,]
                {
                    { "1", "John", "Doe",false },
                    { "2", "Jane", "Doe",false },
                    { "3", "Bob", "Smith",false },
                    { "4", "Jeremy", "Black",false },
                    { "5", "Jenny", "White",false },
                    { "6", "Lola", "Smith",false },
                    { "7", "Μary", "Green",false },
                    { "8", "Sofia", "Altar",false },
                    { "9", "Harry", "Potter",false },
                    { "10", "Alex", "Been",false },
                    { "11", "Lisa", "Mineli",false },
                    { "12", "Andrea", "Newton",false },
                    { "13", "Fenia", "Batzoni",true },
                });


            // Add seed data for the Movies table
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title", "Description", "Genre" },
                values: new object[,]
                {
                    { "1", "The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", 6},
                    { "2", "The Godfather", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",6   },
                    { "3", "The Dark Knight", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 6 },
                    { "4", "The Lord of the Rings: The Fellowship of the Ring", "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", 6 },
                    { "5", "Forrest Gump", "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", 6},
                    { "6", "Star Wars: Episode IV - A New Hope", "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", 12 },
                    { "7", "The Matrix", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", 12 },
                    { "8", "The Silence of the Lambs", "A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.", 8 },
                    { "9", "The Lion King", "A lion cub prince is tricked by a treacherous uncle into thinking he caused his father's death and flees into exile in despair, only to learn in adulthood his identity and his responsibilities.", 2 },
                    { "10", "The Godfather: Part II", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", 6 }
                });

            // Add seed data for the MovieCopies table
            migrationBuilder.InsertData(
                table: "MovieCopies",
                columns: new[] { "Id", "MovieId", "IsAvailable" },
                values: new object[,]
                {
                    { "1", "1" , false},
                    { "2", "1" , true},
                    { "3", "1", true },
                    { "4", "2" , false},
                    { "5", "2" , true},
                    { "6", "2" , true},
                    { "7", "3" , false},
                    { "8", "3" , true},
                    { "9", "3", true },
                    { "10", "4" , false},
                    { "11", "4" , true},
                    { "12", "4" , true},
                    { "13", "5" , false},
                    { "14", "5" , true},
                    { "15", "6", true },
                    { "16", "6" , false},
                    { "17", "7" , true},
                    { "18", "7" , true},
                    { "19", "8" , false},
                    { "20", "8" , true},
                    { "21", "8", true },
                    { "22", "8" , true},
                    { "23", "9" , false},
                    { "24", "10" , true},
                });

            // Add seed data for the MovieRents table
            migrationBuilder.InsertData(
                table: "MovieRents",
                columns: new[] { "Id", "MovieTitle", "MovieCopyId", "CustomerId", "RentDate" , "ReturnDate", "Comment", "MovieId"},
                values: new object[,]
                {
                    { "1", "The Shawshank Redemption", "1","1", new DateTime(2022, 4, 1), new DateTime(2022, 4, 8), null,"1" },
                    { "2", "The Godfather", "4" ,"2", new DateTime(2022, 4, 1), new DateTime(2022, 4, 8), "Σχόλιο" ,"2"},
                    { "3", "The Dark Knight", "7","3", new DateTime(2022, 4, 10), new DateTime(2022, 4, 17), null,"3" },
                    { "4", "The Lord of the Rings: The Fellowship of the Ring", "10", "4",new DateTime(2022, 4, 11), new DateTime(2022, 4, 18), null,"4" },
                    { "5", "Forrest Gump", "13", "5", new DateTime(2022, 4, 12), new DateTime(2022, 4, 19), null ,"5"},
                    { "6", "Star Wars: Episode IV - A New Hope", "16","6", new DateTime(2022, 4, 13), new DateTime(2022, 4, 20), null,"6" },
                    { "7", "The Matrix","19" , "7",new DateTime(2022, 4, 15),new DateTime(2022, 4, 22), null,"7" },
                    { "8", "The Silence of the Lambs","23" , "8", new DateTime(2022, 4, 17), new DateTime(2022, 4, 24),  "Σχόλιο","8" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
