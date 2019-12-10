/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


$.ajax({
    async: true,
    type: "GET",
    url: "https://localhost:5001/api/listaProductos",
    datatype: "json",
    contentType: "application/json; charset=utf-8",
    success: function(result) {

        console.log(result);
    },
    error: function(result) {
        console.log(result);
    }
});