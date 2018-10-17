var res;
function Podaci(){
	
var baseUrl = "http://localhost:4050";

	var url = baseUrl +"/Firma/Prikazi";

		

		$.getJSON(url , function(data) {
			var tbl_body = "";

			var i =0;
			$.each(data, function() {
				var tbl_row = "";
				$.each(this, function(k , v) {
					tbl_row += "<td>"+v+"</td>";
				});

				tbl_row+= "<td> <a href='" + baseUrl + "/Firma/Obrisi?id="  + data[i].ID + "'>Obrisi</a> </td>"
				tbl_row+= "<td> <a href='" + baseUrl + "/Firma/Izmjeni?id="  + data[i++].ID + "'>Izmjeni</a> </td>"
				tbl_body += "<tr>" + tbl_row + "</tr>";
			           
			})
			$("#tabela").html(tbl_body);
		});
		
	}



