// See https://aka.ms/new-console-template for more information
using SpaceExplorer.Models;

Console.WriteLine("Mars’taki yüzeyin sağ üst köşesinin koordinatlarını boşluk bırakarak giriniz");
var boundaries = Console.ReadLine();
if (string.IsNullOrEmpty(boundaries))
    Console.WriteLine("Değer girmediniz!");
else
{
    var boundaryList = boundaries.Split(' ');
    if (boundaryList.Length != 2)
    {
        Console.WriteLine("Eksik yada yanlış değer girdiniz!");
    }
    else
    {
        if (!int.TryParse(boundaryList[0], out int x) || !int.TryParse(boundaryList[1], out int y))
        {
            Console.WriteLine("Eksik yada yanlış değer girdiniz!");
        }
        else
        {
            var space = new Space(x, y);
            var resp1 = CreateExplorer(1, space);
            if (resp1.IsSuccess)
            {
                var explorer1 = resp1.Explorer;
                Console.WriteLine("Gezgin 1 için harf katarını giriniz");
                var katar1 = Console.ReadLine();
                string sonuc1 = Move(space, explorer1, katar1);
                if (string.IsNullOrEmpty(sonuc1))
                {
                    var resp2= CreateExplorer(2, space);
                    if (resp2.IsSuccess)
                    {
                        var explorer2= resp2.Explorer;
                        Console.WriteLine("Gezgin 2 için harf katarını giriniz");
                        var katar2 = Console.ReadLine();
                        string sonuc2 = Move(space, explorer2, katar2);
                        if (string.IsNullOrEmpty(sonuc2))
                        {
                            Console.WriteLine(explorer1.LocationX + " " + explorer1.LocationY + " " + explorer1.Direction);
                            Console.WriteLine(explorer2.LocationX + " " + explorer2.LocationY + " " + explorer2.Direction);
                        }
                        else
                        {
                            Console.WriteLine(sonuc2);

                        }
                    }
                    else
                    {
                        Console.WriteLine(resp2.ErrorMessage);
                    }
                }
                else
                {
                    Console.WriteLine(sonuc1);
                }
            }
            else
            {
                Console.WriteLine(resp1.ErrorMessage);
            }
        }
    }
}
string Move(Space space, Explorer explorer, string? moveList)
{
    string message = "";
    var harfList = new List<char>() { 'L', 'M', 'R' };
    if (!string.IsNullOrEmpty(moveList))
    {
        bool wrongValue = false;
        foreach (var harf in moveList)
        {
            if (!harfList.Any(x => x == harf))
            {
                wrongValue = true;
                break;
            }
        }
        if (!wrongValue)
        {
            foreach (var move in moveList)
            {
                if (move == 'M')
                {
                    switch (explorer.Direction)
                    {
                        case "N":
                            if (explorer.LocationY < space.BoundryY)
                                explorer.LocationY++;
                            break;
                        case "E":
                            if (explorer.LocationX < space.BoundryX)
                                explorer.LocationX++;
                            break;
                        case "S":
                            if (explorer.LocationY >0)
                                explorer.LocationY--;
                            break;
                        case "W":
                            if (explorer.LocationX > 0)
                                explorer.LocationX--;
                            break;
                    }
                }
                else
                {
                    switch(move)
                    {
                        case 'L':
                            if (explorer.Direction == "N")
                                explorer.Direction = "W";
                            else if(explorer.Direction == "E")
                                explorer.Direction = "N";
                            else if (explorer.Direction == "W")
                                explorer.Direction = "S";
                            else
                                explorer.Direction = "E";
                            break;
                        case 'R':
                            if (explorer.Direction == "N")
                                explorer.Direction = "E";
                            else if (explorer.Direction == "E")
                                explorer.Direction = "S";
                            else if (explorer.Direction == "W")
                                explorer.Direction = "N";
                            else
                                explorer.Direction = "W";
                            break;
                    }
                }
            }
        }
        else
        {
            message="Yanlış değer girdiniz!";
        }
    }
    else
    {
        message="Değer girmediniz!";
    }
    return message;
}

CreateResponse CreateExplorer(int sira,Space space)
{
    var resp = new CreateResponse();
    string errorMessage = "";
    Console.WriteLine($"Gezgin {sira} 'in ilk konumunu ve yönünü boşluk bırakarak giriniz");
    var explorer = Console.ReadLine();
    if (string.IsNullOrEmpty(explorer))
    {
        resp.ErrorMessage = "Değer girmediniz!";
        resp.IsSuccess = false;
    }
    else
    {
        var location1list = explorer.Split(" ");
        if (location1list.Length != 3)
        {
            resp.IsSuccess = false;
            resp.ErrorMessage ="Eksik yada yanlış değer girdiniz!";
        }
        else
        {
            var directions = new List<string>() { "N", "E", "S", "W" };
            if (!int.TryParse(location1list[0], out int x1) || !int.TryParse(location1list[1], out int y1) || !directions.Any(x => x == location1list[2]))
            {
                resp.IsSuccess = false;
                resp.ErrorMessage = "Eksik yada yanlış değer girdiniz!";
            }
            else
            {
                var firstExplorer = new Explorer(x1, y1, location1list[2]);
                resp.IsSuccess = true;
                resp.Explorer = firstExplorer;
            }
        }
    }
    return resp;
}
