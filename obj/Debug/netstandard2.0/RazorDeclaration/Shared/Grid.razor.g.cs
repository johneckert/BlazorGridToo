#pragma checksum "/Users/johneckert/Code/BlazorGridToo/Shared/Grid.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "677b893ae186a442d89616f4432f580c34955f64"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorGridToo.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using BlazorGridToo;

#line default
#line hidden
#line 7 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using BlazorGridToo.Shared;

#line default
#line hidden
#line 8 "/Users/johneckert/Code/BlazorGridToo/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
    public partial class Grid : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 66 "/Users/johneckert/Code/BlazorGridToo/Shared/Grid.razor"
       
    [PARAMETER] public string Title;

    [PARAMETER] Pet[] pets;

    private string FilterValue { get; set; } = "";

    private string SortedBy = "";

    private string NameSort = "none";

    private string BreedSort = "none";

    private string AgeSort = "none";

    Pet[] pets;

    Pet[] visiblePets;

    Pet selectedRow = new Pet();

    string DetailOpen = "hidden";

    private void OpenPopup( Pet pet ) 
    {
        DetailOpen = (DetailOpen == "hidden") ? "" : "hidden";
        selectedRow = pet;
    }

    private void SortTable (String column)
    {
        if (column == SortedBy) {
            IEnumerable<Pet> sortQuery =
                from pet in pets
                orderby pet.GetType().GetProperty(column).GetValue(pet, null) descending
                select pet;

                visiblePets = sortQuery.ToArray();

                if (column == "Name") {
                    NameSort = "desc";
                    BreedSort = "none";
                    AgeSort = "none";
                }


                if (column == "Breed") {
                    BreedSort = "desc";
                    NameSort = "none";
                    AgeSort = "none";
                }


                if (column == "Age") {
                    AgeSort = "desc";
                    NameSort = "none";
                    BreedSort = "none";
                }

                SortedBy = column + "-desc";

                
        }
        else {
            IEnumerable<Pet> sortQuery =
                from pet in pets
                orderby pet.GetType().GetProperty(column).GetValue(pet, null)
                select pet;

                visiblePets = sortQuery.ToArray();
                
                if (column == "Name") {
                    NameSort = "asc";
                    BreedSort = "none";
                    AgeSort = "none";
                }


                if (column == "Breed") {
                    BreedSort = "asc";
                    NameSort = "none";
                    AgeSort = "none";
                }


                if (column == "Age") {
                    AgeSort = "asc";
                    NameSort = "none";
                    BreedSort = "none";
                }

                SortedBy = column;
        }
    }

    private void ClosePopup() 
    {
        DetailOpen = "hidden";    
    }

    protected override async Task OnInitializedAsync()
    {
        visiblePets = pets = await Http.GetJsonAsync<Pet[]>("http://localhost:3000");
    }

    public void FilterPets() 
    {
        IEnumerable<Pet> petQuery =
            from pet in pets
            where pet.Name.Contains(FilterValue) || pet.Breed.Contains(FilterValue)|| pet.Age.ToString().Contains(FilterValue)
            select pet;

        visiblePets = petQuery.ToArray();

    }

    public class Pet 
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
