var baseUrl = "http://localhost:4050//";

var brojacMBox = 0;

function AlertPoruke(poruka)
{
	var MBoxID= "MBox" + brojacMBox++;
	var now = new Date(Date.now());
	var formatted = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
	var x =  "<div class='alert alert-primary' role='alert' id='" + MBoxID + "'> " + formatted + ": " + poruka+ "</div>";

	$("#alert-div").append(x);
	
	$("#" + MBoxID).delay(5000).slideUp(200, function() {
    $(this).alert('close');
});
}

function BtnUpdate(firmaID)
{
	var url = baseUrl +"/Firma/GetByID?ID="+firmaID;

	AlertPoruke("Podaci se učitavaju sa servera...");
	
	$.getJSON(url , function(data) {
		AlertPoruke("Podaci su preuzeti sa servera...");
		
		$("#ID").val(data.ID);
		$("#Naziv").val(data.Naziv);
		$("#JIB").val(data.JIB);
		$("#PDV").val(data.PDV);
		$("#Adresa").val(data.Adresa);
		
		$("#OpstinaID>option").attr('selected', false);
		$("#OpstinaID>option:eq(" + data.OpstinaID + ")").attr('selected', true);
	});
}

function BtnDodaj()
{
	AlertPoruke("Forma za dodavanje nove firme");
	
	$("#ID").val(0);
	$("#Naziv").val("");
	$("#JIB").val("");
	$("#PDV").val("");
	$("#Adresa").val("");
	$("#OpstinaID").val("");
}

function BtnSnimi()
{
	var forma = $("#UpdateForma");
	var podaci =  forma.serialize();
	var url = baseUrl +"/Firma/Snimi";

	AlertPoruke(podaci);
	$.ajax({
    type: "POST",
    url: url,
    data: podaci,
    dataType: "html",
    success: function(p) {
		AlertPoruke("Podaci su snimljeni" + p);
		BtnPrikazi();
    },
    error: function(p) {
      	AlertPoruke("Podaic nisu snimljeni. " + p  );
    }
	});
	
}


function BtnObrisi(firmaID)
{
	var url = baseUrl +"/Firma/Obrisi?ID="+firmaID;
	
	  $.post(url, function(data, status){
        alert("Obrisano: " + data + "\nStatus: " + status);
		BtnPrikazi();
    });
}

function BtnPrikazi(){
	
	var url = baseUrl +"/Firma/Prikazi";

	AlertPoruke("Podaci se učitavaju sa servera...");
	
	$.getJSON(url , function(data) {
		AlertPoruke("Podaci su preuzeti sa servera...");
		var tbl_body = "";

		var size= data.length;
		
		var i =0;
		$.each(data, function() {
			
			var tbl_row = "";
			
			$.each(this, function(k , v) {
				tbl_row += "<td>"+v+"</td>";
			});

			var firmaid = data[i].ID;
			
			tbl_row+= "<td>";
			
			tbl_row+= "<button onclick='BtnUpdate(" + firmaid + ")' class='btn btn-success'>Update</button>";
			tbl_row+= "<button onclick='BtnObrisi(" + firmaid + ")' class='btn btn-danger'>Obrisi</button>";
			tbl_row+= "</td>";
			
			tbl_body += "<tr>" + tbl_row + "</tr>";
			i++;
				   
		});
		$("#tabelabody").html(tbl_body);
	});
		
}


function LoadOpstine(){
	
	var url = baseUrl +"/Firma/GetOpstine";

	
	
	$.getJSON(url , function(data) {
		
			
		for(var i=0; i<data.length; i++)
		{
			var item = "<option value='" + data[i].ID + "'>" + data[i].Naziv + "</option>";
			$("#OpstinaID").append(item);
		}
		
		
	});
		
}
	
	
$( document ).ready(function() {
    console.log( "ready!" );
	LoadOpstine();
	AlertPoruke("Aplikacija je učitana. Upute za grešku <i>No 'Access-Control-Allow-Origin' header is present...</i> možete naći na <a href='https://stackoverflow.com/questions/20035101/why-does-my-javascript-get-a-no-access-control-allow-origin-header-is-present'>stackoverflow</a>");
	
});



