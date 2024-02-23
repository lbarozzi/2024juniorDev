using System.Net.Http.Json;
using WebApplication1.Models;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string url = "https://localhost:7095/api/Students";

var mycli = new HttpClient();

//var v = await  mycli.GetAsync(url);
var v = mycli.GetAsync(url).Result;

if (v.IsSuccessStatusCode) {
    //var dt = v.Content.ReadAsStringAsync().Result;
    var dt = await  v.Content.ReadFromJsonAsync<IEnumerable<Student>>();
    //Console.WriteLine(dt);
    foreach(var s in dt) {
           Console.WriteLine(s);
    }
}else {
    Console.WriteLine($"Fail to get {url}: {v.ReasonPhrase}");  
}

//Console.WriteLine(v.GetType().Name);




