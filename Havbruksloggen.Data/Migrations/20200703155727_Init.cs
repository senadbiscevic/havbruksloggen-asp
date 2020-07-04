using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Havbruksloggen.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fishing");

            migrationBuilder.CreateTable(
                name: "Boat",
                schema: "Fishing",
                columns: table => new
                {
                    BoatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BuildNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Loa = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    B = table.Column<decimal>(type: "decimal(8, 1)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boat", x => x.BoatId);
                });

            migrationBuilder.CreateTable(
                name: "Sailor",
                schema: "Fishing",
                columns: table => new
                {
                    SailorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CertifiedUntil = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailor", x => x.SailorId);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                schema: "Fishing",
                columns: table => new
                {
                    CrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SailorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewId);
                    table.ForeignKey(
                        name: "FK_Crew_Boat_BoatId",
                        column: x => x.BoatId,
                        principalSchema: "Fishing",
                        principalTable: "Boat",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crew_Sailor_SailorId",
                        column: x => x.SailorId,
                        principalSchema: "Fishing",
                        principalTable: "Sailor",
                        principalColumn: "SailorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Fishing",
                table: "Boat",
                columns: new[] { "BoatId", "B", "BuildNumber", "Loa", "Name", "Picture", "Producer" },
                values: new object[,]
                {
                    { new Guid("abc8f531-f212-4fe6-a708-447d3eeed64f"), 5m, "G0JIGZDOJHGA", 13m, "Paula", "https://picsum.photos/200/300?random=806", "Von" },
                    { new Guid("77551c4e-1c84-4637-92cb-40f66dff1742"), 4m, "E2VV645893OV", 14m, "Naomi", "https://picsum.photos/200/300?random=28", "Dietrich" },
                    { new Guid("bc032226-a793-4a2f-9aad-47695df88340"), 4m, "SZTIEK17NLEI", 19m, "Camille", "https://picsum.photos/200/300?random=670", "Gislason" },
                    { new Guid("b21194f6-23d7-4531-9ec0-073613db90af"), 4m, "A18V2IJEBL5B", 14m, "Juana", "https://picsum.photos/200/300?random=557", "Wehner" },
                    { new Guid("4c02cfb6-caca-4017-b165-078807609a62"), 4m, "ZA78PMJ7H3EE", 17m, "Jill", "https://picsum.photos/200/300?random=560", "Wisoky" },
                    { new Guid("dc8b7163-fe1e-42e3-ae49-ad3fb0d26c58"), 5m, "UBVNI81SP3SO", 19m, "Olive", "https://picsum.photos/200/300?random=970", "Bahringer" },
                    { new Guid("5d920301-62bc-4968-a65d-aa60583e3318"), 5m, "FGUR327T23ZM", 16m, "Penny", "https://picsum.photos/200/300?random=79", "Rice" },
                    { new Guid("01d021b4-9609-4a0e-bd38-cad25bca4d3f"), 5m, "S01N8C15F2Z1", 12m, "Nicole", "https://picsum.photos/200/300?random=173", "Hackett" },
                    { new Guid("105b9630-126d-4309-b4f2-2f5c7d4ad92c"), 5m, "OTR947KDT0AE", 12m, "Tracey", "https://picsum.photos/200/300?random=983", "Crooks" },
                    { new Guid("7e240968-cc50-4e37-86c8-596b4ba09fcf"), 4m, "GONE6PJ372CU", 16m, "Norma", "https://picsum.photos/200/300?random=155", "Emmerich" },
                    { new Guid("0337154a-9929-43e9-b3eb-179e2820cb7d"), 5m, "EAHZZLK8CFL3", 16m, "Elaine", "https://picsum.photos/200/300?random=3", "Gutkowski" },
                    { new Guid("4264cf51-e6d8-496e-876e-0ed817e324ed"), 4m, "3LZPF0NXAEOA", 18m, "Susan", "https://picsum.photos/200/300?random=810", "Windler" },
                    { new Guid("7e04f373-5950-4e01-8892-cd40d2f7c4ad"), 4m, "5V6H5XZIMJEK", 12m, "Mattie", "https://picsum.photos/200/300?random=897", "Ortiz" },
                    { new Guid("30cdaae7-9ffc-4314-928d-128f82f64f6e"), 5m, "885AD80R5ULS", 19m, "Cathy", "https://picsum.photos/200/300?random=374", "Heaney" },
                    { new Guid("21407ba2-81df-452c-9a47-38f4e5dabc71"), 5m, "7ARHBSE8IS0B", 17m, "Colleen", "https://picsum.photos/200/300?random=352", "Kerluke" },
                    { new Guid("ed0ce4d9-b947-419a-9134-db4d2c804b2a"), 4m, "1S3GGBHXRFF1", 15m, "Mabel", "https://picsum.photos/200/300?random=288", "Roberts" },
                    { new Guid("9b5f623d-a958-45b6-a6fe-134db2a21ddb"), 5m, "E06L6EXF234N", 12m, "Kelley", "https://picsum.photos/200/300?random=368", "Jaskolski" },
                    { new Guid("27ceb0c6-0fe1-4874-a7b1-f133f15c7fa6"), 5m, "7BS3BNFF0AEZ", 14m, "Miriam", "https://picsum.photos/200/300?random=549", "Lindgren" },
                    { new Guid("d2827cfc-ffbc-4119-acdd-63a64a9a13af"), 5m, "6U4KFK7M272O", 18m, "Susan", "https://picsum.photos/200/300?random=532", "Abbott" },
                    { new Guid("84106fda-d514-4752-9d48-e350958f56d6"), 4m, "71O5P0GVL8HI", 14m, "Kathy", "https://picsum.photos/200/300?random=733", "Mann" }
                });

            migrationBuilder.InsertData(
                schema: "Fishing",
                table: "Sailor",
                columns: new[] { "SailorId", "BirthDate", "CertifiedUntil", "Email", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("6a5f8fad-9bfb-4b2e-b305-7be044ac0ebb"), new DateTime(1987, 4, 9, 19, 41, 42, 882, DateTimeKind.Local).AddTicks(343), new DateTime(2020, 4, 7, 7, 16, 1, 985, DateTimeKind.Local).AddTicks(6462), "kathrynschuppe@havbruksloggen.no", "Kathryn Schuppe", "https://picsum.photos/200/300?random=636" },
                    { new Guid("1171f8a8-b385-4a44-9990-5c9bfea22a77"), new DateTime(1986, 3, 25, 16, 54, 29, 53, DateTimeKind.Local).AddTicks(488), new DateTime(2020, 5, 28, 13, 2, 29, 252, DateTimeKind.Local).AddTicks(1431), "edgardobradtke@havbruksloggen.no", "Edgardo Bradtke", "https://picsum.photos/200/300?random=828" },
                    { new Guid("3131552f-667b-4cf2-a674-42eff98cc497"), new DateTime(1982, 4, 25, 17, 36, 13, 759, DateTimeKind.Local).AddTicks(7107), new DateTime(2020, 10, 7, 1, 14, 26, 140, DateTimeKind.Local).AddTicks(2777), "antonioconn@havbruksloggen.no", "Antonio Conn", "https://picsum.photos/200/300?random=681" },
                    { new Guid("f186777b-24ed-43d7-8cfe-850b446f014b"), new DateTime(1990, 10, 27, 16, 57, 13, 883, DateTimeKind.Local).AddTicks(4732), new DateTime(2020, 11, 2, 10, 14, 20, 6, DateTimeKind.Local).AddTicks(5379), "nedrahowell@havbruksloggen.no", "Nedra Howell", "https://picsum.photos/200/300?random=84" },
                    { new Guid("3a3dfcb4-77f0-4c22-884d-915661f62b10"), new DateTime(1984, 8, 6, 9, 10, 48, 143, DateTimeKind.Local).AddTicks(1017), new DateTime(2020, 10, 12, 17, 14, 14, 615, DateTimeKind.Local).AddTicks(8792), "seamuswilliamson@havbruksloggen.no", "Seamus Williamson", "https://picsum.photos/200/300?random=316" },
                    { new Guid("6d223ebe-2871-44c0-9f0b-c8f67553ae77"), new DateTime(1993, 7, 3, 12, 17, 13, 834, DateTimeKind.Local).AddTicks(9477), new DateTime(2020, 4, 8, 18, 32, 0, 676, DateTimeKind.Local).AddTicks(6195), "kristinstoltenberg@havbruksloggen.no", "Kristin Stoltenberg", "https://picsum.photos/200/300?random=552" },
                    { new Guid("fc754f25-16ca-4a0e-b7ce-87ed906b67a0"), new DateTime(1992, 8, 3, 20, 0, 58, 91, DateTimeKind.Local).AddTicks(9136), new DateTime(2020, 6, 19, 3, 41, 39, 672, DateTimeKind.Local).AddTicks(6771), "houstonconnelly@havbruksloggen.no", "Houston Connelly", "https://picsum.photos/200/300?random=58" },
                    { new Guid("f05f16d6-d77c-40a7-9ce9-fddd2570785c"), new DateTime(1998, 12, 11, 23, 19, 26, 11, DateTimeKind.Local).AddTicks(5290), new DateTime(2020, 5, 9, 5, 14, 30, 15, DateTimeKind.Local).AddTicks(777), "angelinahudson@havbruksloggen.no", "Angelina Hudson", "https://picsum.photos/200/300?random=485" },
                    { new Guid("ce94e2e8-ae7d-4fab-bc40-6aa3a2c74b7d"), new DateTime(1985, 4, 29, 22, 21, 10, 208, DateTimeKind.Local).AddTicks(5882), new DateTime(2020, 7, 20, 16, 9, 36, 203, DateTimeKind.Local).AddTicks(8149), "tristiangreenholt@havbruksloggen.no", "Tristian Greenholt", "https://picsum.photos/200/300?random=716" },
                    { new Guid("de0edb9c-1260-48cb-bb44-d180398e9ede"), new DateTime(1984, 7, 10, 1, 2, 30, 776, DateTimeKind.Local).AddTicks(298), new DateTime(2020, 6, 14, 0, 55, 2, 709, DateTimeKind.Local).AddTicks(5423), "carmellapouros@havbruksloggen.no", "Carmella Pouros", "https://picsum.photos/200/300?random=1013" },
                    { new Guid("fe3c6bd2-e7ab-4755-b65f-57bca8ad9a26"), new DateTime(1993, 1, 3, 16, 8, 44, 465, DateTimeKind.Local).AddTicks(9088), new DateTime(2020, 11, 14, 20, 22, 8, 777, DateTimeKind.Local).AddTicks(4945), "delilahmcglynn@havbruksloggen.no", "Delilah McGlynn", "https://picsum.photos/200/300?random=17" },
                    { new Guid("b5cdf71e-78f2-45e4-a8fa-f3ade0a3eb07"), new DateTime(1996, 8, 4, 17, 37, 8, 542, DateTimeKind.Local).AddTicks(8056), new DateTime(2020, 10, 29, 11, 59, 15, 452, DateTimeKind.Local).AddTicks(9618), "joshkuvalis@havbruksloggen.no", "Josh Kuvalis", "https://picsum.photos/200/300?random=210" },
                    { new Guid("c26a1f5e-f89e-48e2-8762-75614aefa0ce"), new DateTime(1986, 11, 30, 22, 19, 12, 351, DateTimeKind.Local).AddTicks(8301), new DateTime(2020, 7, 11, 18, 34, 2, 268, DateTimeKind.Local).AddTicks(1550), "ibrahimhirthe@havbruksloggen.no", "Ibrahim Hirthe", "https://picsum.photos/200/300?random=902" },
                    { new Guid("f10c709d-e1fd-4adb-9021-18b789ecdb9e"), new DateTime(1992, 4, 6, 6, 56, 41, 59, DateTimeKind.Local).AddTicks(4630), new DateTime(2020, 12, 9, 14, 46, 55, 322, DateTimeKind.Local).AddTicks(8580), "jakobwiza@havbruksloggen.no", "Jakob Wiza", "https://picsum.photos/200/300?random=700" },
                    { new Guid("b4296dd2-3c09-4a18-a124-4b038a631b42"), new DateTime(1987, 8, 4, 12, 45, 22, 506, DateTimeKind.Local).AddTicks(3852), new DateTime(2020, 7, 8, 1, 28, 14, 578, DateTimeKind.Local).AddTicks(2351), "schuylermacejkovic@havbruksloggen.no", "Schuyler Macejkovic", "https://picsum.photos/200/300?random=305" },
                    { new Guid("1898e7db-8ec5-4f8d-a6ff-ad8f683ea340"), new DateTime(1996, 1, 5, 7, 50, 14, 198, DateTimeKind.Local).AddTicks(6256), new DateTime(2020, 6, 9, 3, 47, 34, 676, DateTimeKind.Local).AddTicks(2648), "calebsatterfield@havbruksloggen.no", "Caleb Satterfield", "https://picsum.photos/200/300?random=310" },
                    { new Guid("711de92b-3de2-41f5-bd67-ba4eef11d7ef"), new DateTime(1989, 9, 15, 23, 3, 13, 230, DateTimeKind.Local).AddTicks(1503), new DateTime(2020, 7, 17, 4, 14, 24, 823, DateTimeKind.Local).AddTicks(8764), "martinakilback@havbruksloggen.no", "Martina Kilback", "https://picsum.photos/200/300?random=374" },
                    { new Guid("c14092a5-9137-4e02-82ad-1e21b11b4b3c"), new DateTime(1988, 9, 16, 4, 53, 46, 322, DateTimeKind.Local).AddTicks(2087), new DateTime(2020, 11, 13, 17, 34, 18, 545, DateTimeKind.Local).AddTicks(2898), "aidannicolas@havbruksloggen.no", "Aidan Nicolas", "https://picsum.photos/200/300?random=608" },
                    { new Guid("2ac7aa07-b4fb-4de8-b460-43a1953d8e80"), new DateTime(1997, 7, 25, 5, 17, 45, 984, DateTimeKind.Local).AddTicks(2952), new DateTime(2021, 2, 20, 15, 29, 58, 542, DateTimeKind.Local).AddTicks(9105), "breanaklocko@havbruksloggen.no", "Breana Klocko", "https://picsum.photos/200/300?random=176" },
                    { new Guid("91ebed85-2645-443f-b826-c01a17fe850f"), new DateTime(1989, 6, 19, 0, 1, 57, 886, DateTimeKind.Local).AddTicks(2327), new DateTime(2020, 8, 9, 10, 26, 26, 353, DateTimeKind.Local).AddTicks(3091), "bayleebode@havbruksloggen.no", "Baylee Bode", "https://picsum.photos/200/300?random=694" },
                    { new Guid("d95642ad-c61b-4431-a3c0-32de2bbb4c94"), new DateTime(1996, 11, 13, 23, 5, 48, 716, DateTimeKind.Local).AddTicks(2374), new DateTime(2021, 3, 20, 9, 38, 42, 986, DateTimeKind.Local).AddTicks(8066), "brettkirlin@havbruksloggen.no", "Brett Kirlin", "https://picsum.photos/200/300?random=490" },
                    { new Guid("2b04462e-f35d-4915-847f-4a4fe8761c4a"), new DateTime(2000, 2, 12, 21, 56, 33, 2, DateTimeKind.Local).AddTicks(8155), new DateTime(2020, 6, 4, 14, 42, 2, 900, DateTimeKind.Local).AddTicks(8799), "lilyanbogisich@havbruksloggen.no", "Lilyan Bogisich", "https://picsum.photos/200/300?random=575" },
                    { new Guid("0fbbd2bc-34dc-4396-94ad-7e803f5884ba"), new DateTime(1985, 12, 5, 20, 43, 4, 293, DateTimeKind.Local).AddTicks(188), new DateTime(2021, 3, 21, 19, 6, 50, 470, DateTimeKind.Local).AddTicks(7046), "loyalkuhic@havbruksloggen.no", "Loyal Kuhic", "https://picsum.photos/200/300?random=959" },
                    { new Guid("8096f866-dab6-4577-8cba-31334379367d"), new DateTime(1995, 12, 3, 2, 1, 50, 978, DateTimeKind.Local).AddTicks(7299), new DateTime(2020, 12, 28, 12, 25, 55, 270, DateTimeKind.Local).AddTicks(774), "lillad'amore@havbruksloggen.no", "Lilla D'Amore", "https://picsum.photos/200/300?random=579" },
                    { new Guid("3a82ba0b-ad3a-44fa-90a1-dde9f3280b9e"), new DateTime(1990, 12, 12, 15, 16, 25, 204, DateTimeKind.Local).AddTicks(7160), new DateTime(2020, 6, 12, 0, 3, 22, 534, DateTimeKind.Local).AddTicks(9488), "chaimhauck@havbruksloggen.no", "Chaim Hauck", "https://picsum.photos/200/300?random=664" },
                    { new Guid("50803659-4859-42d9-986a-ef54f6fbd5ff"), new DateTime(1992, 12, 29, 14, 33, 4, 83, DateTimeKind.Local).AddTicks(5870), new DateTime(2021, 3, 2, 20, 45, 40, 781, DateTimeKind.Local).AddTicks(4062), "bellleffler@havbruksloggen.no", "Bell Leffler", "https://picsum.photos/200/300?random=464" },
                    { new Guid("198b675c-0286-43d3-8512-a63bf603f6f5"), new DateTime(1999, 8, 12, 15, 10, 30, 231, DateTimeKind.Local).AddTicks(9640), new DateTime(2020, 6, 29, 14, 15, 57, 116, DateTimeKind.Local).AddTicks(9078), "isabellezulauf@havbruksloggen.no", "Isabelle Zulauf", "https://picsum.photos/200/300?random=66" },
                    { new Guid("4f933310-ae15-445f-a8ed-d3e42032ac95"), new DateTime(1987, 4, 22, 1, 6, 8, 999, DateTimeKind.Local).AddTicks(5759), new DateTime(2020, 7, 28, 5, 31, 26, 337, DateTimeKind.Local).AddTicks(1477), "kyleebartell@havbruksloggen.no", "Kylee Bartell", "https://picsum.photos/200/300?random=691" },
                    { new Guid("308cd422-fbd3-4a8c-a007-b0313be6e6fd"), new DateTime(1981, 11, 18, 8, 20, 44, 379, DateTimeKind.Local).AddTicks(8445), new DateTime(2021, 2, 8, 9, 48, 15, 68, DateTimeKind.Local).AddTicks(6895), "karikuhn@havbruksloggen.no", "Kari Kuhn", "https://picsum.photos/200/300?random=725" },
                    { new Guid("8e08fbbf-f455-4acf-8960-93ea3b868e52"), new DateTime(1981, 2, 24, 22, 47, 7, 817, DateTimeKind.Local).AddTicks(8550), new DateTime(2020, 5, 28, 10, 13, 27, 344, DateTimeKind.Local).AddTicks(236), "trentheathcote@havbruksloggen.no", "Trent Heathcote", "https://picsum.photos/200/300?random=258" },
                    { new Guid("703ab49a-1935-4a35-9958-aa374ebc27a9"), new DateTime(1994, 4, 8, 7, 20, 6, 376, DateTimeKind.Local).AddTicks(4971), new DateTime(2020, 5, 14, 7, 0, 37, 87, DateTimeKind.Local).AddTicks(4075), "janaeconroy@havbruksloggen.no", "Janae Conroy", "https://picsum.photos/200/300?random=71" },
                    { new Guid("e010ca47-3064-46bd-ac4c-702d579b3dfa"), new DateTime(1990, 7, 17, 17, 48, 10, 753, DateTimeKind.Local).AddTicks(3516), new DateTime(2020, 8, 30, 10, 55, 49, 803, DateTimeKind.Local).AddTicks(2094), "caspercasper@havbruksloggen.no", "Casper Casper", "https://picsum.photos/200/300?random=142" },
                    { new Guid("edbccf59-e507-4cf4-8ed4-68f9c0c6d657"), new DateTime(1983, 2, 4, 10, 52, 34, 809, DateTimeKind.Local).AddTicks(7207), new DateTime(2021, 1, 4, 12, 43, 44, 463, DateTimeKind.Local).AddTicks(9539), "bertaschimmel@havbruksloggen.no", "Berta Schimmel", "https://picsum.photos/200/300?random=504" },
                    { new Guid("1df1ed34-03c6-4a7f-acf3-2f37bf259457"), new DateTime(1988, 3, 27, 11, 43, 13, 6, DateTimeKind.Local).AddTicks(247), new DateTime(2020, 10, 5, 22, 52, 12, 996, DateTimeKind.Local).AddTicks(8535), "auroreo'kon@havbruksloggen.no", "Aurore O'Kon", "https://picsum.photos/200/300?random=86" },
                    { new Guid("487bc93b-9a02-4360-acb7-76bc81f660cd"), new DateTime(1993, 9, 12, 15, 38, 51, 835, DateTimeKind.Local).AddTicks(1834), new DateTime(2021, 2, 13, 20, 36, 18, 875, DateTimeKind.Local).AddTicks(2241), "nonaflatley@havbruksloggen.no", "Nona Flatley", "https://picsum.photos/200/300?random=898" },
                    { new Guid("2a011901-4237-4a74-9c2e-fd8485d20f75"), new DateTime(1982, 10, 19, 10, 55, 33, 762, DateTimeKind.Local).AddTicks(4852), new DateTime(2020, 11, 30, 3, 22, 42, 371, DateTimeKind.Local).AddTicks(8937), "elfriedakrajcik@havbruksloggen.no", "Elfrieda Krajcik", "https://picsum.photos/200/300?random=150" },
                    { new Guid("4ecb8261-72e8-42bd-b4ed-ba31f5d0f661"), new DateTime(1997, 11, 19, 4, 27, 18, 403, DateTimeKind.Local).AddTicks(3989), new DateTime(2020, 5, 2, 1, 45, 53, 790, DateTimeKind.Local).AddTicks(1851), "stanleyauer@havbruksloggen.no", "Stanley Auer", "https://picsum.photos/200/300?random=332" },
                    { new Guid("52fee0ab-199d-4619-bfac-b58818c6191c"), new DateTime(1989, 12, 25, 12, 13, 24, 211, DateTimeKind.Local).AddTicks(1438), new DateTime(2020, 8, 31, 21, 29, 57, 842, DateTimeKind.Local).AddTicks(3039), "reynoldupton@havbruksloggen.no", "Reynold Upton", "https://picsum.photos/200/300?random=15" },
                    { new Guid("29941b97-33ac-4aee-b8ae-4bb2c92b1e99"), new DateTime(1980, 10, 20, 20, 9, 29, 778, DateTimeKind.Local).AddTicks(7752), new DateTime(2020, 12, 3, 17, 12, 44, 614, DateTimeKind.Local).AddTicks(6096), "maidawuckert@havbruksloggen.no", "Maida Wuckert", "https://picsum.photos/200/300?random=500" },
                    { new Guid("c9211b77-3347-4b20-bc19-1aa6c5a6fccf"), new DateTime(1988, 12, 29, 5, 55, 7, 773, DateTimeKind.Local).AddTicks(4523), new DateTime(2020, 6, 2, 3, 37, 48, 283, DateTimeKind.Local).AddTicks(7223), "isidroheller@havbruksloggen.no", "Isidro Heller", "https://picsum.photos/200/300?random=201" },
                    { new Guid("7e2e6062-0040-4f99-8e4e-f208b10bf3f9"), new DateTime(1984, 6, 26, 9, 27, 21, 557, DateTimeKind.Local).AddTicks(6102), new DateTime(2021, 1, 1, 22, 5, 51, 668, DateTimeKind.Local).AddTicks(7406), "deloresroberts@havbruksloggen.no", "Delores Roberts", "https://picsum.photos/200/300?random=11" },
                    { new Guid("a72d13e6-c3bc-46da-9cbd-bfa88f76f570"), new DateTime(1984, 3, 2, 9, 14, 51, 164, DateTimeKind.Local).AddTicks(3563), new DateTime(2020, 5, 22, 10, 52, 42, 11, DateTimeKind.Local).AddTicks(1334), "maybelleconn@havbruksloggen.no", "Maybelle Conn", "https://picsum.photos/200/300?random=172" },
                    { new Guid("65d7bd2b-274f-4ac9-91bf-afcdab39cd39"), new DateTime(1998, 10, 15, 21, 36, 30, 787, DateTimeKind.Local).AddTicks(8122), new DateTime(2020, 6, 14, 17, 54, 53, 764, DateTimeKind.Local).AddTicks(4582), "jessmaggio@havbruksloggen.no", "Jess Maggio", "https://picsum.photos/200/300?random=745" },
                    { new Guid("a5096988-66c1-4a1e-a6f3-c7ac510487f0"), new DateTime(1990, 7, 16, 21, 42, 15, 347, DateTimeKind.Local).AddTicks(8267), new DateTime(2020, 10, 31, 6, 58, 23, 760, DateTimeKind.Local).AddTicks(8980), "patriciajerde@havbruksloggen.no", "Patricia Jerde", "https://picsum.photos/200/300?random=820" },
                    { new Guid("a44b008b-e2c6-43ee-a1be-fc27293c87cd"), new DateTime(1987, 7, 7, 16, 59, 6, 892, DateTimeKind.Local).AddTicks(9803), new DateTime(2021, 1, 23, 23, 4, 33, 880, DateTimeKind.Local).AddTicks(8791), "eloystamm@havbruksloggen.no", "Eloy Stamm", "https://picsum.photos/200/300?random=412" },
                    { new Guid("7017f2b5-e139-47eb-9e5b-407d07a7c3f3"), new DateTime(1993, 3, 30, 8, 54, 12, 292, DateTimeKind.Local).AddTicks(9289), new DateTime(2020, 5, 14, 18, 55, 30, 161, DateTimeKind.Local).AddTicks(9950), "murphygreenholt@havbruksloggen.no", "Murphy Greenholt", "https://picsum.photos/200/300?random=115" },
                    { new Guid("2401b780-60e1-48fd-999a-b7a15518eaa8"), new DateTime(1999, 3, 16, 3, 37, 30, 872, DateTimeKind.Local).AddTicks(7777), new DateTime(2020, 9, 30, 2, 19, 44, 943, DateTimeKind.Local).AddTicks(5497), "aronmclaughlin@havbruksloggen.no", "Aron McLaughlin", "https://picsum.photos/200/300?random=28" },
                    { new Guid("3e041cc0-49a0-44b9-a1a6-ff2ce0982dc9"), new DateTime(1989, 8, 11, 17, 37, 20, 781, DateTimeKind.Local).AddTicks(8434), new DateTime(2020, 10, 17, 4, 27, 59, 238, DateTimeKind.Local).AddTicks(3932), "devyngrady@havbruksloggen.no", "Devyn Grady", "https://picsum.photos/200/300?random=202" },
                    { new Guid("a3088364-463d-464c-946a-0d90f548b73a"), new DateTime(1980, 9, 10, 17, 49, 47, 541, DateTimeKind.Local).AddTicks(8809), new DateTime(2020, 9, 10, 9, 13, 40, 548, DateTimeKind.Local).AddTicks(8213), "jeramykuphal@havbruksloggen.no", "Jeramy Kuphal", "https://picsum.photos/200/300?random=838" },
                    { new Guid("0b4d817e-9e5d-4a36-abe0-821ea39d7341"), new DateTime(1993, 3, 29, 6, 3, 52, 545, DateTimeKind.Local).AddTicks(9399), new DateTime(2020, 7, 28, 6, 38, 40, 8, DateTimeKind.Local).AddTicks(6499), "theronskiles@havbruksloggen.no", "Theron Skiles", "https://picsum.photos/200/300?random=465" },
                    { new Guid("ac58ba33-b734-4afd-bed4-88ea6b7ef6e4"), new DateTime(1984, 10, 15, 1, 14, 21, 874, DateTimeKind.Local).AddTicks(6463), new DateTime(2020, 7, 7, 17, 35, 45, 634, DateTimeKind.Local).AddTicks(5471), "isaiahsatterfield@havbruksloggen.no", "Isaiah Satterfield", "https://picsum.photos/200/300?random=173" },
                    { new Guid("8bb49817-d674-4154-8d62-cd9daf01e35c"), new DateTime(1989, 12, 6, 7, 4, 15, 196, DateTimeKind.Local).AddTicks(2572), new DateTime(2020, 10, 10, 20, 57, 57, 888, DateTimeKind.Local).AddTicks(1837), "opalpowlowski@havbruksloggen.no", "Opal Powlowski", "https://picsum.photos/200/300?random=372" },
                    { new Guid("41854816-6352-4c66-a1d4-eba6797a9f90"), new DateTime(1997, 11, 2, 5, 31, 44, 498, DateTimeKind.Local).AddTicks(6885), new DateTime(2020, 8, 26, 2, 27, 56, 460, DateTimeKind.Local).AddTicks(110), "kaileemedhurst@havbruksloggen.no", "Kailee Medhurst", "https://picsum.photos/200/300?random=544" },
                    { new Guid("fe94688b-aaae-4f22-830d-2b4fdbc80fe8"), new DateTime(1993, 2, 18, 23, 29, 10, 16, DateTimeKind.Local).AddTicks(3400), new DateTime(2020, 5, 17, 20, 2, 44, 678, DateTimeKind.Local).AddTicks(2848), "derekherman@havbruksloggen.no", "Derek Herman", "https://picsum.photos/200/300?random=35" },
                    { new Guid("3f4c1037-086a-438e-b93f-803e57724c63"), new DateTime(1985, 5, 2, 21, 42, 30, 881, DateTimeKind.Local).AddTicks(1679), new DateTime(2020, 9, 13, 2, 27, 12, 828, DateTimeKind.Local).AddTicks(5168), "keonmccullough@havbruksloggen.no", "Keon McCullough", "https://picsum.photos/200/300?random=601" },
                    { new Guid("3ff00be6-146c-4202-8502-7c95f8384690"), new DateTime(1997, 2, 4, 14, 18, 32, 801, DateTimeKind.Local).AddTicks(8432), new DateTime(2020, 7, 6, 12, 13, 39, 959, DateTimeKind.Local).AddTicks(8471), "abduldurgan@havbruksloggen.no", "Abdul Durgan", "https://picsum.photos/200/300?random=953" },
                    { new Guid("22b13e24-1377-403d-b0fe-6d2444a7e316"), new DateTime(1985, 5, 2, 7, 16, 59, 386, DateTimeKind.Local).AddTicks(7605), new DateTime(2021, 2, 21, 16, 40, 35, 61, DateTimeKind.Local).AddTicks(7341), "erikashanahan@havbruksloggen.no", "Erika Shanahan", "https://picsum.photos/200/300?random=252" },
                    { new Guid("74d640b2-7161-42a8-99c0-2f775d2b0c46"), new DateTime(1994, 5, 11, 3, 54, 12, 114, DateTimeKind.Local).AddTicks(1360), new DateTime(2020, 7, 15, 22, 10, 3, 752, DateTimeKind.Local).AddTicks(4591), "sanfordrosenbaum@havbruksloggen.no", "Sanford Rosenbaum", "https://picsum.photos/200/300?random=808" },
                    { new Guid("048ea611-c655-44b3-9933-d32e2bbf0801"), new DateTime(1994, 8, 13, 11, 38, 2, 373, DateTimeKind.Local).AddTicks(7904), new DateTime(2020, 10, 12, 13, 6, 56, 942, DateTimeKind.Local).AddTicks(8886), "rutherolfson@havbruksloggen.no", "Ruthe Rolfson", "https://picsum.photos/200/300?random=107" },
                    { new Guid("ca7abe1d-ed1f-4ee6-8d8e-3d5079bbb397"), new DateTime(1996, 8, 9, 12, 44, 40, 341, DateTimeKind.Local).AddTicks(984), new DateTime(2021, 3, 25, 7, 16, 12, 557, DateTimeKind.Local).AddTicks(4222), "kileyoberbrunner@havbruksloggen.no", "Kiley Oberbrunner", "https://picsum.photos/200/300?random=436" },
                    { new Guid("bdbcd5a3-44af-44c2-a0f4-fb41d129f8dc"), new DateTime(1989, 6, 1, 13, 29, 24, 516, DateTimeKind.Local).AddTicks(3336), new DateTime(2020, 10, 13, 1, 54, 31, 440, DateTimeKind.Local).AddTicks(679), "ariannakemmer@havbruksloggen.no", "Arianna Kemmer", "https://picsum.photos/200/300?random=824" },
                    { new Guid("8df9df6e-2b01-4169-80fa-d07ee079bf71"), new DateTime(1981, 7, 11, 17, 43, 58, 133, DateTimeKind.Local).AddTicks(1494), new DateTime(2020, 4, 28, 21, 44, 40, 227, DateTimeKind.Local).AddTicks(2638), "joweissnat@havbruksloggen.no", "Jo Weissnat", "https://picsum.photos/200/300?random=980" },
                    { new Guid("05d10782-f9bf-483f-b6a9-97bf7132024c"), new DateTime(1999, 8, 22, 22, 50, 28, 640, DateTimeKind.Local).AddTicks(2336), new DateTime(2020, 10, 22, 18, 1, 31, 432, DateTimeKind.Local).AddTicks(728), "dannyblanda@havbruksloggen.no", "Danny Blanda", "https://picsum.photos/200/300?random=2" },
                    { new Guid("422e77d9-f245-4af6-9d67-062c0f1344d8"), new DateTime(1994, 8, 11, 8, 52, 56, 953, DateTimeKind.Local).AddTicks(3607), new DateTime(2021, 3, 19, 5, 14, 6, 414, DateTimeKind.Local).AddTicks(3987), "adolphusdare@havbruksloggen.no", "Adolphus Dare", "https://picsum.photos/200/300?random=473" },
                    { new Guid("4215461d-338b-4924-9f96-b21f0c122127"), new DateTime(1981, 8, 16, 13, 0, 27, 427, DateTimeKind.Local).AddTicks(6577), new DateTime(2020, 11, 11, 15, 9, 12, 819, DateTimeKind.Local).AddTicks(8382), "devonlangworth@havbruksloggen.no", "Devon Langworth", "https://picsum.photos/200/300?random=6" },
                    { new Guid("5e177999-af9b-4eb6-8067-96992a3159c8"), new DateTime(1985, 7, 15, 10, 18, 40, 770, DateTimeKind.Local).AddTicks(6543), new DateTime(2020, 10, 10, 12, 18, 53, 299, DateTimeKind.Local).AddTicks(8752), "georgettehartmann@havbruksloggen.no", "Georgette Hartmann", "https://picsum.photos/200/300?random=850" },
                    { new Guid("0f0e1b4a-f3bc-4de4-8113-bffe90076a58"), new DateTime(1981, 3, 12, 11, 10, 38, 379, DateTimeKind.Local).AddTicks(375), new DateTime(2020, 6, 11, 5, 22, 36, 520, DateTimeKind.Local).AddTicks(9009), "kaitlynwolf@havbruksloggen.no", "Kaitlyn Wolf", "https://picsum.photos/200/300?random=744" },
                    { new Guid("95f1cb69-9279-4221-a770-1abf3d97f226"), new DateTime(1988, 6, 10, 8, 18, 43, 809, DateTimeKind.Local).AddTicks(5781), new DateTime(2020, 9, 29, 5, 7, 17, 931, DateTimeKind.Local).AddTicks(2192), "amberaufderhar@havbruksloggen.no", "Amber Aufderhar", "https://picsum.photos/200/300?random=607" },
                    { new Guid("e01dda82-cd0f-419e-a75e-8d03189faf33"), new DateTime(1999, 1, 10, 10, 3, 7, 753, DateTimeKind.Local).AddTicks(2468), new DateTime(2020, 4, 6, 6, 33, 56, 220, DateTimeKind.Local).AddTicks(8004), "janetblick@havbruksloggen.no", "Janet Blick", "https://picsum.photos/200/300?random=25" },
                    { new Guid("5cf886bf-c819-4384-9c85-7f01c5b899c1"), new DateTime(1990, 5, 28, 22, 37, 34, 99, DateTimeKind.Local).AddTicks(4143), new DateTime(2021, 3, 9, 0, 55, 33, 791, DateTimeKind.Local).AddTicks(5455), "zakaryschroeder@havbruksloggen.no", "Zakary Schroeder", "https://picsum.photos/200/300?random=242" },
                    { new Guid("49e3efa9-cb0c-4b17-bb2f-1f2070e8b19b"), new DateTime(1981, 7, 2, 17, 47, 27, 511, DateTimeKind.Local).AddTicks(6111), new DateTime(2021, 3, 4, 14, 33, 12, 597, DateTimeKind.Local).AddTicks(6771), "adityaschmeler@havbruksloggen.no", "Aditya Schmeler", "https://picsum.photos/200/300?random=871" },
                    { new Guid("a3255694-e867-40a1-8f72-6be4a56014f1"), new DateTime(1994, 9, 15, 15, 30, 7, 159, DateTimeKind.Local).AddTicks(9522), new DateTime(2020, 7, 16, 23, 55, 40, 108, DateTimeKind.Local).AddTicks(9394), "dominicharvey@havbruksloggen.no", "Dominic Harvey", "https://picsum.photos/200/300?random=629" },
                    { new Guid("ee7c7560-ea68-4abe-847f-99d36a41a1d4"), new DateTime(1998, 4, 9, 20, 45, 14, 77, DateTimeKind.Local).AddTicks(5503), new DateTime(2020, 5, 17, 8, 2, 4, 521, DateTimeKind.Local).AddTicks(279), "royceconn@havbruksloggen.no", "Royce Conn", "https://picsum.photos/200/300?random=545" },
                    { new Guid("7a305445-b8a2-45a8-b451-a6eb972436b8"), new DateTime(1981, 1, 18, 11, 55, 30, 516, DateTimeKind.Local).AddTicks(8674), new DateTime(2020, 4, 4, 14, 20, 41, 233, DateTimeKind.Local).AddTicks(6979), "aliciahagenes@havbruksloggen.no", "Alicia Hagenes", "https://picsum.photos/200/300?random=519" },
                    { new Guid("e7917315-1117-45b6-91e6-f937ed6df549"), new DateTime(1996, 4, 5, 14, 52, 28, 476, DateTimeKind.Local).AddTicks(8901), new DateTime(2021, 3, 16, 22, 47, 28, 689, DateTimeKind.Local).AddTicks(861), "randalbalistreri@havbruksloggen.no", "Randal Balistreri", "https://picsum.photos/200/300?random=422" },
                    { new Guid("13557d3c-42d0-4174-ad60-70ad6d06eae3"), new DateTime(1995, 11, 30, 3, 19, 49, 170, DateTimeKind.Local).AddTicks(7550), new DateTime(2020, 11, 15, 19, 53, 59, 773, DateTimeKind.Local).AddTicks(3687), "lauriecassin@havbruksloggen.no", "Laurie Cassin", "https://picsum.photos/200/300?random=303" },
                    { new Guid("2cbda40f-9b3a-494e-93ab-24250c92c539"), new DateTime(1983, 2, 24, 2, 26, 31, 745, DateTimeKind.Local).AddTicks(4675), new DateTime(2021, 1, 16, 22, 10, 12, 349, DateTimeKind.Local).AddTicks(2593), "josiannestracke@havbruksloggen.no", "Josianne Stracke", "https://picsum.photos/200/300?random=965" },
                    { new Guid("69fdb1a6-7d02-4e00-9fa4-fd67956c5347"), new DateTime(1981, 2, 23, 11, 9, 17, 63, DateTimeKind.Local).AddTicks(514), new DateTime(2020, 4, 18, 11, 42, 48, 161, DateTimeKind.Local).AddTicks(5809), "rosemarykshlerin@havbruksloggen.no", "Rosemary Kshlerin", "https://picsum.photos/200/300?random=716" },
                    { new Guid("8986b09f-1f72-4948-9344-5865920238f3"), new DateTime(1985, 4, 3, 4, 41, 14, 505, DateTimeKind.Local).AddTicks(2124), new DateTime(2020, 10, 16, 8, 12, 57, 217, DateTimeKind.Local).AddTicks(1694), "alfredbins@havbruksloggen.no", "Alfred Bins", "https://picsum.photos/200/300?random=907" },
                    { new Guid("649dec79-2434-4edd-95be-abea364b728b"), new DateTime(1995, 10, 26, 2, 53, 17, 139, DateTimeKind.Local).AddTicks(3248), new DateTime(2020, 12, 19, 1, 16, 29, 34, DateTimeKind.Local).AddTicks(2757), "leeabernathy@havbruksloggen.no", "Lee Abernathy", "https://picsum.photos/200/300?random=815" }
                });

            migrationBuilder.InsertData(
                schema: "Fishing",
                table: "Crew",
                columns: new[] { "CrewId", "BoatId", "Role", "SailorId" },
                values: new object[,]
                {
                    { new Guid("4d2de380-0ae1-409c-9a8a-73cd8dd3d33e"), new Guid("dc8b7163-fe1e-42e3-ae49-ad3fb0d26c58"), (short)2, new Guid("22b13e24-1377-403d-b0fe-6d2444a7e316") },
                    { new Guid("75ae3027-7a68-413f-bc81-54e2a5d6f0c6"), new Guid("27ceb0c6-0fe1-4874-a7b1-f133f15c7fa6"), (short)2, new Guid("f186777b-24ed-43d7-8cfe-850b446f014b") },
                    { new Guid("7e599ff2-ea5b-4f95-9a5f-e3860abac00e"), new Guid("30cdaae7-9ffc-4314-928d-128f82f64f6e"), (short)0, new Guid("fc754f25-16ca-4a0e-b7ce-87ed906b67a0") },
                    { new Guid("3e09ac34-9505-41a6-9b7c-b289f4ae10e7"), new Guid("7e04f373-5950-4e01-8892-cd40d2f7c4ad"), (short)3, new Guid("1171f8a8-b385-4a44-9990-5c9bfea22a77") },
                    { new Guid("10077fc4-9050-4fd9-963e-de3ccd66ed11"), new Guid("84106fda-d514-4752-9d48-e350958f56d6"), (short)2, new Guid("1171f8a8-b385-4a44-9990-5c9bfea22a77") },
                    { new Guid("abc769a9-d4dc-42f6-b5c1-c3c92ac9a7ad"), new Guid("abc8f531-f212-4fe6-a708-447d3eeed64f"), (short)1, new Guid("f05f16d6-d77c-40a7-9ce9-fddd2570785c") },
                    { new Guid("657863cd-1c2a-4565-8445-0e4944715828"), new Guid("01d021b4-9609-4a0e-bd38-cad25bca4d3f"), (short)2, new Guid("de0edb9c-1260-48cb-bb44-d180398e9ede") },
                    { new Guid("f51965e1-5d7a-4ab2-ac59-bbdf849cc7a2"), new Guid("ed0ce4d9-b947-419a-9134-db4d2c804b2a"), (short)0, new Guid("de0edb9c-1260-48cb-bb44-d180398e9ede") },
                    { new Guid("b0c0f0e7-5bce-4c21-90fb-1776af2fb19d"), new Guid("ed0ce4d9-b947-419a-9134-db4d2c804b2a"), (short)1, new Guid("1898e7db-8ec5-4f8d-a6ff-ad8f683ea340") },
                    { new Guid("6ecafb43-5b8a-4aa0-a252-029d0dab7a50"), new Guid("0337154a-9929-43e9-b3eb-179e2820cb7d"), (short)2, new Guid("ce94e2e8-ae7d-4fab-bc40-6aa3a2c74b7d") },
                    { new Guid("0f1e8ea3-5831-4757-a0ae-067c2ed1bdc1"), new Guid("ed0ce4d9-b947-419a-9134-db4d2c804b2a"), (short)3, new Guid("ce94e2e8-ae7d-4fab-bc40-6aa3a2c74b7d") },
                    { new Guid("c885420a-8fb1-4a42-8c22-9b2ae41b18ca"), new Guid("105b9630-126d-4309-b4f2-2f5c7d4ad92c"), (short)1, new Guid("b5cdf71e-78f2-45e4-a8fa-f3ade0a3eb07") },
                    { new Guid("5817e6dc-6749-4255-b328-d67f3843451e"), new Guid("27ceb0c6-0fe1-4874-a7b1-f133f15c7fa6"), (short)0, new Guid("b5cdf71e-78f2-45e4-a8fa-f3ade0a3eb07") },
                    { new Guid("7e097193-2597-44ed-a943-d45107d2e5fb"), new Guid("7e04f373-5950-4e01-8892-cd40d2f7c4ad"), (short)0, new Guid("f10c709d-e1fd-4adb-9021-18b789ecdb9e") },
                    { new Guid("d1caf5b7-ca4b-4048-9052-c76fb956468c"), new Guid("d2827cfc-ffbc-4119-acdd-63a64a9a13af"), (short)3, new Guid("29941b97-33ac-4aee-b8ae-4bb2c92b1e99") },
                    { new Guid("1cd66894-bd0b-446a-b27b-696175a332a2"), new Guid("d2827cfc-ffbc-4119-acdd-63a64a9a13af"), (short)1, new Guid("29941b97-33ac-4aee-b8ae-4bb2c92b1e99") },
                    { new Guid("5343e808-41be-473f-9bd3-1ddfce5163b2"), new Guid("21407ba2-81df-452c-9a47-38f4e5dabc71"), (short)1, new Guid("8986b09f-1f72-4948-9344-5865920238f3") },
                    { new Guid("ece95117-ea19-419f-851e-bd8a9ff1b0a9"), new Guid("84106fda-d514-4752-9d48-e350958f56d6"), (short)1, new Guid("ce94e2e8-ae7d-4fab-bc40-6aa3a2c74b7d") },
                    { new Guid("b94be240-0e6c-419e-ac30-3f0d04db4a85"), new Guid("30cdaae7-9ffc-4314-928d-128f82f64f6e"), (short)3, new Guid("8df9df6e-2b01-4169-80fa-d07ee079bf71") },
                    { new Guid("6d2928d3-546c-4f01-8d60-7f9b1408a27a"), new Guid("7e240968-cc50-4e37-86c8-596b4ba09fcf"), (short)3, new Guid("1898e7db-8ec5-4f8d-a6ff-ad8f683ea340") },
                    { new Guid("461e8c46-7520-4979-8ef3-1878ee113b84"), new Guid("d2827cfc-ffbc-4119-acdd-63a64a9a13af"), (short)2, new Guid("91ebed85-2645-443f-b826-c01a17fe850f") },
                    { new Guid("cf16e308-7131-41b4-9e15-33ed2641ce1f"), new Guid("b21194f6-23d7-4531-9ec0-073613db90af"), (short)0, new Guid("2b04462e-f35d-4915-847f-4a4fe8761c4a") },
                    { new Guid("ca232576-7d8a-4f0c-b4fc-0331b3ea64b7"), new Guid("bc032226-a793-4a2f-9aad-47695df88340"), (short)3, new Guid("0fbbd2bc-34dc-4396-94ad-7e803f5884ba") },
                    { new Guid("4687d532-6eda-46a0-a9ae-6d43b3edba5e"), new Guid("4264cf51-e6d8-496e-876e-0ed817e324ed"), (short)2, new Guid("0fbbd2bc-34dc-4396-94ad-7e803f5884ba") },
                    { new Guid("058a301a-745e-4888-8ace-f1a908b43ee5"), new Guid("77551c4e-1c84-4637-92cb-40f66dff1742"), (short)1, new Guid("8096f866-dab6-4577-8cba-31334379367d") },
                    { new Guid("040d2e9e-f5b8-4482-be00-fe0ade5e397c"), new Guid("84106fda-d514-4752-9d48-e350958f56d6"), (short)0, new Guid("8096f866-dab6-4577-8cba-31334379367d") },
                    { new Guid("52cf84f5-27ea-4d8f-9e20-8d5e68c13d5b"), new Guid("4c02cfb6-caca-4017-b165-078807609a62"), (short)3, new Guid("3a82ba0b-ad3a-44fa-90a1-dde9f3280b9e") },
                    { new Guid("1505bdd6-1fd5-48f6-b26c-74bacfade8df"), new Guid("9b5f623d-a958-45b6-a6fe-134db2a21ddb"), (short)2, new Guid("50803659-4859-42d9-986a-ef54f6fbd5ff") },
                    { new Guid("77182aac-eceb-47db-92ff-cd349511c0ae"), new Guid("105b9630-126d-4309-b4f2-2f5c7d4ad92c"), (short)3, new Guid("1898e7db-8ec5-4f8d-a6ff-ad8f683ea340") },
                    { new Guid("a117b22a-3dc5-40ea-91ff-6d0bb7bd3bd6"), new Guid("7e240968-cc50-4e37-86c8-596b4ba09fcf"), (short)1, new Guid("4f933310-ae15-445f-a8ed-d3e42032ac95") },
                    { new Guid("e9e707fb-bac0-4bc6-a47c-01cb1d304188"), new Guid("abc8f531-f212-4fe6-a708-447d3eeed64f"), (short)3, new Guid("e010ca47-3064-46bd-ac4c-702d579b3dfa") },
                    { new Guid("8fe3af8a-ab10-4b2a-a1f4-ed7446c9b8cf"), new Guid("ed0ce4d9-b947-419a-9134-db4d2c804b2a"), (short)2, new Guid("1df1ed34-03c6-4a7f-acf3-2f37bf259457") },
                    { new Guid("a655266b-795e-4178-a931-7275263f64c5"), new Guid("dc8b7163-fe1e-42e3-ae49-ad3fb0d26c58"), (short)1, new Guid("487bc93b-9a02-4360-acb7-76bc81f660cd") },
                    { new Guid("1cb6c0b4-f83e-46f8-9f90-402561e08182"), new Guid("105b9630-126d-4309-b4f2-2f5c7d4ad92c"), (short)0, new Guid("487bc93b-9a02-4360-acb7-76bc81f660cd") },
                    { new Guid("162188be-139d-48b8-98f7-578032ebaee7"), new Guid("5d920301-62bc-4968-a65d-aa60583e3318"), (short)1, new Guid("2a011901-4237-4a74-9c2e-fd8485d20f75") },
                    { new Guid("e68cf374-8400-43ae-b555-499060461159"), new Guid("bc032226-a793-4a2f-9aad-47695df88340"), (short)1, new Guid("91ebed85-2645-443f-b826-c01a17fe850f") },
                    { new Guid("a611849e-00f0-49ca-acb9-c23d19658a4e"), new Guid("01d021b4-9609-4a0e-bd38-cad25bca4d3f"), (short)1, new Guid("91ebed85-2645-443f-b826-c01a17fe850f") },
                    { new Guid("476b2ab9-4b6b-48be-b685-0cd1d4fa506b"), new Guid("7e240968-cc50-4e37-86c8-596b4ba09fcf"), (short)2, new Guid("e010ca47-3064-46bd-ac4c-702d579b3dfa") },
                    { new Guid("58885f2d-09cf-48f7-b781-7fe26a4eaec0"), new Guid("4264cf51-e6d8-496e-876e-0ed817e324ed"), (short)0, new Guid("422e77d9-f245-4af6-9d67-062c0f1344d8") },
                    { new Guid("ea802218-c25e-4175-ab93-1a5c8f581773"), new Guid("77551c4e-1c84-4637-92cb-40f66dff1742"), (short)3, new Guid("4215461d-338b-4924-9f96-b21f0c122127") },
                    { new Guid("3a97a8aa-fe67-40ce-90a7-bf190199a325"), new Guid("4c02cfb6-caca-4017-b165-078807609a62"), (short)2, new Guid("5e177999-af9b-4eb6-8067-96992a3159c8") },
                    { new Guid("852628fe-dff8-4e0a-aaed-7456cbbdec10"), new Guid("d2827cfc-ffbc-4119-acdd-63a64a9a13af"), (short)0, new Guid("a5096988-66c1-4a1e-a6f3-c7ac510487f0") },
                    { new Guid("bc2e22c1-afe6-49b3-ab88-5e3af2b86eec"), new Guid("9b5f623d-a958-45b6-a6fe-134db2a21ddb"), (short)0, new Guid("a5096988-66c1-4a1e-a6f3-c7ac510487f0") },
                    { new Guid("8ecd64eb-8024-4e88-a876-986330c467cf"), new Guid("27ceb0c6-0fe1-4874-a7b1-f133f15c7fa6"), (short)3, new Guid("a44b008b-e2c6-43ee-a1be-fc27293c87cd") },
                    { new Guid("6b6e46b6-1b53-407f-a9dc-14f87936e64c"), new Guid("0337154a-9929-43e9-b3eb-179e2820cb7d"), (short)3, new Guid("2401b780-60e1-48fd-999a-b7a15518eaa8") },
                    { new Guid("108ed46b-a226-4de2-9d47-bfd31542ed92"), new Guid("7e04f373-5950-4e01-8892-cd40d2f7c4ad"), (short)2, new Guid("2401b780-60e1-48fd-999a-b7a15518eaa8") },
                    { new Guid("35d69523-44d6-4333-84fb-6895e11d26f3"), new Guid("bc032226-a793-4a2f-9aad-47695df88340"), (short)2, new Guid("3e041cc0-49a0-44b9-a1a6-ff2ce0982dc9") },
                    { new Guid("e516ecf4-c215-4b00-bf37-5c34e9f8e06d"), new Guid("dc8b7163-fe1e-42e3-ae49-ad3fb0d26c58"), (short)0, new Guid("3e041cc0-49a0-44b9-a1a6-ff2ce0982dc9") },
                    { new Guid("ad624feb-2744-4668-896f-224e87e3251c"), new Guid("9b5f623d-a958-45b6-a6fe-134db2a21ddb"), (short)3, new Guid("a72d13e6-c3bc-46da-9cbd-bfa88f76f570") },
                    { new Guid("15ccb162-9b5b-4025-822e-43de5e0d3a84"), new Guid("5d920301-62bc-4968-a65d-aa60583e3318"), (short)0, new Guid("0b4d817e-9e5d-4a36-abe0-821ea39d7341") },
                    { new Guid("aae4a340-57ae-440a-ada7-4052c9ea243b"), new Guid("21407ba2-81df-452c-9a47-38f4e5dabc71"), (short)2, new Guid("74d640b2-7161-42a8-99c0-2f775d2b0c46") },
                    { new Guid("40536bad-75a5-47fe-98cf-4450c2b2649c"), new Guid("abc8f531-f212-4fe6-a708-447d3eeed64f"), (short)0, new Guid("74d640b2-7161-42a8-99c0-2f775d2b0c46") },
                    { new Guid("374503eb-1f9a-41c4-9a99-8974f226dbd6"), new Guid("30cdaae7-9ffc-4314-928d-128f82f64f6e"), (short)2, new Guid("ac58ba33-b734-4afd-bed4-88ea6b7ef6e4") },
                    { new Guid("9a782d5f-7cf8-46a4-ab8f-1d0c8d1f6661"), new Guid("01d021b4-9609-4a0e-bd38-cad25bca4d3f"), (short)3, new Guid("8bb49817-d674-4154-8d62-cd9daf01e35c") },
                    { new Guid("1f143280-794d-44ba-adfe-d57dfb56ff33"), new Guid("21407ba2-81df-452c-9a47-38f4e5dabc71"), (short)0, new Guid("8bb49817-d674-4154-8d62-cd9daf01e35c") },
                    { new Guid("86f5a586-5c70-4e46-a65b-b8f337ce333a"), new Guid("5d920301-62bc-4968-a65d-aa60583e3318"), (short)2, new Guid("41854816-6352-4c66-a1d4-eba6797a9f90") },
                    { new Guid("10a22efc-a9ad-4c5b-8e42-5a6a3d6530bf"), new Guid("105b9630-126d-4309-b4f2-2f5c7d4ad92c"), (short)2, new Guid("3ff00be6-146c-4202-8502-7c95f8384690") },
                    { new Guid("af72ec69-00c1-478b-b44f-7ee37866b5e6"), new Guid("01d021b4-9609-4a0e-bd38-cad25bca4d3f"), (short)0, new Guid("74d640b2-7161-42a8-99c0-2f775d2b0c46") },
                    { new Guid("10c60381-c9f9-4a73-aaeb-40d7fb63664f"), new Guid("4c02cfb6-caca-4017-b165-078807609a62"), (short)0, new Guid("a3088364-463d-464c-946a-0d90f548b73a") },
                    { new Guid("106ef846-6e3d-41f9-97e9-3a981e2a7b1a"), new Guid("bc032226-a793-4a2f-9aad-47695df88340"), (short)0, new Guid("a3088364-463d-464c-946a-0d90f548b73a") },
                    { new Guid("bdab8dc3-01b4-4736-a73e-ad11f01270b1"), new Guid("0337154a-9929-43e9-b3eb-179e2820cb7d"), (short)1, new Guid("a3088364-463d-464c-946a-0d90f548b73a") },
                    { new Guid("6d65b7ef-219a-4549-a09a-532291407b1d"), new Guid("7e04f373-5950-4e01-8892-cd40d2f7c4ad"), (short)1, new Guid("5e177999-af9b-4eb6-8067-96992a3159c8") },
                    { new Guid("a7a6daa2-04d9-4cb8-8bb9-3e6d8f7b618b"), new Guid("abc8f531-f212-4fe6-a708-447d3eeed64f"), (short)2, new Guid("5e177999-af9b-4eb6-8067-96992a3159c8") },
                    { new Guid("dbf7bf97-d3a5-4f62-94bb-2bd77fbcb70d"), new Guid("b21194f6-23d7-4531-9ec0-073613db90af"), (short)3, new Guid("c9211b77-3347-4b20-bc19-1aa6c5a6fccf") },
                    { new Guid("79249ef2-7d33-4047-a9cf-63b395c0867f"), new Guid("4264cf51-e6d8-496e-876e-0ed817e324ed"), (short)1, new Guid("c9211b77-3347-4b20-bc19-1aa6c5a6fccf") },
                    { new Guid("2e9a67eb-aa33-4894-bc56-5473bf377661"), new Guid("b21194f6-23d7-4531-9ec0-073613db90af"), (short)1, new Guid("49e3efa9-cb0c-4b17-bb2f-1f2070e8b19b") },
                    { new Guid("aad72cdd-1149-4afc-8544-99c9882065d7"), new Guid("27ceb0c6-0fe1-4874-a7b1-f133f15c7fa6"), (short)1, new Guid("7a305445-b8a2-45a8-b451-a6eb972436b8") },
                    { new Guid("886c9ebf-6895-401a-8306-0bf789d19aaa"), new Guid("84106fda-d514-4752-9d48-e350958f56d6"), (short)3, new Guid("7a305445-b8a2-45a8-b451-a6eb972436b8") },
                    { new Guid("bf6be785-01ae-4988-8cb3-6692114967d5"), new Guid("21407ba2-81df-452c-9a47-38f4e5dabc71"), (short)3, new Guid("7a305445-b8a2-45a8-b451-a6eb972436b8") },
                    { new Guid("03ebd3a1-b1ad-4e12-92b0-1d09a6515905"), new Guid("77551c4e-1c84-4637-92cb-40f66dff1742"), (short)2, new Guid("e7917315-1117-45b6-91e6-f937ed6df549") },
                    { new Guid("29385611-5749-48bd-a9c6-b6ff0d8c8f58"), new Guid("0337154a-9929-43e9-b3eb-179e2820cb7d"), (short)0, new Guid("13557d3c-42d0-4174-ad60-70ad6d06eae3") },
                    { new Guid("13a6d5f9-7987-4955-a334-f0aabb9656ba"), new Guid("7e240968-cc50-4e37-86c8-596b4ba09fcf"), (short)0, new Guid("13557d3c-42d0-4174-ad60-70ad6d06eae3") },
                    { new Guid("a2844eba-95fb-42ca-b4c7-e34294f65c14"), new Guid("30cdaae7-9ffc-4314-928d-128f82f64f6e"), (short)1, new Guid("13557d3c-42d0-4174-ad60-70ad6d06eae3") },
                    { new Guid("35492b25-8d13-4edd-bfc2-7dcea745274d"), new Guid("77551c4e-1c84-4637-92cb-40f66dff1742"), (short)0, new Guid("2cbda40f-9b3a-494e-93ab-24250c92c539") },
                    { new Guid("af96ab53-4aee-4aa4-a40f-a0fcddd3d230"), new Guid("dc8b7163-fe1e-42e3-ae49-ad3fb0d26c58"), (short)3, new Guid("2cbda40f-9b3a-494e-93ab-24250c92c539") },
                    { new Guid("b3c58732-d319-45ae-87e8-f8b48be3a866"), new Guid("4c02cfb6-caca-4017-b165-078807609a62"), (short)1, new Guid("69fdb1a6-7d02-4e00-9fa4-fd67956c5347") },
                    { new Guid("d7562ea2-0b90-415f-8aca-90899763303c"), new Guid("9b5f623d-a958-45b6-a6fe-134db2a21ddb"), (short)1, new Guid("69fdb1a6-7d02-4e00-9fa4-fd67956c5347") },
                    { new Guid("8ec579c9-5ed2-4289-a1d7-25cae3437c87"), new Guid("b21194f6-23d7-4531-9ec0-073613db90af"), (short)2, new Guid("048ea611-c655-44b3-9933-d32e2bbf0801") },
                    { new Guid("0712f4b3-6540-4859-a4e4-ac94403fd46a"), new Guid("4264cf51-e6d8-496e-876e-0ed817e324ed"), (short)3, new Guid("d95642ad-c61b-4431-a3c0-32de2bbb4c94") },
                    { new Guid("a89f4015-24f9-4bbd-8022-0d07494d7b9a"), new Guid("5d920301-62bc-4968-a65d-aa60583e3318"), (short)3, new Guid("d95642ad-c61b-4431-a3c0-32de2bbb4c94") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crew_BoatId",
                schema: "Fishing",
                table: "Crew",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_SailorId",
                schema: "Fishing",
                table: "Crew",
                column: "SailorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crew",
                schema: "Fishing");

            migrationBuilder.DropTable(
                name: "Boat",
                schema: "Fishing");

            migrationBuilder.DropTable(
                name: "Sailor",
                schema: "Fishing");
        }
    }
}
