using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;
using System.Runtime.CompilerServices;

namespace WebDay1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        private Rubrica _rubrica;
        private string _firstName;

        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName { get; set; }

        protected readonly DataContext _context;
        public IndexModel(ILogger<IndexModel> logger,Rubrica _rub,DataContext dataContext) {
            _logger = logger;
            //_rubrica = new Rubrica();
            _rubrica = _rub;
            _context = dataContext;
        }

        public void OnGet() {
            this.FirstName = "Leonardo";
            ViewData["SuperPippo"] = "Leonardo";
            //
            var Rub = _context.Anagrafiche
                        //.Where(anag=>anag.FirstName.StartsWith("L"))
                        .OrderBy(anag=>anag.LastName)
                        .ThenBy(anag=>anag.FirstName)
                        .ToList();

            ViewData["Rubrica"] = _rubrica;
            ViewData["Rubrica_EF"]= Rub;
        }

        public void OnPost(string firstName, string lastName,DateTime DOB) {
            
            FirstName = firstName;
            LastName = lastName;
            //_rubrica.Elenco.Add(
            _context.Anagrafiche.Add(
                new Anagrafica() {
                    FirstName=firstName,
                    LastName=lastName,
                    DOB=DOB 
                }
            );

            //TODO:REMEMBER!!!
            _context.SaveChanges();

            var Rub = _context.Anagrafiche
                        //.Where(anag=>anag.FirstName.StartsWith("L"))
                        .OrderBy(anag => anag.LastName)
                        .ThenBy(anag => anag.FirstName)
                        .ToList();
            //*
            ViewData["Rubrica_EF"] = Rub;

            ViewData["Rubrica"] = _rubrica;
            ViewData["Error"] = "CiccioCiccio";
            //*/
            //OnGet();
            //Response.Redirect(this.Request.GetDisplayUrl());
        }
    }
}
