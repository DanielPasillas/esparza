/*
 Arpateck Inc.
 Unidad: _layout.js
 Fecha: 12.Diciembre.2017.
 Autor: daniel.pasillas
 Descripción: Aquí se definen los métodos y funciones para el panel principal - master page.
*/

'use strict';

$(function () {

    setTimeout(menuPedido(), 2000);
});

function menuPedido()
{
    try {

        //fetch universities.
        $.ajax({
            url: 'http://localhost:64954/administrator/resources/getuniversities',
            type: 'post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            async: false,
            success: function (content) {
                $(".list-pedido").html('');

                var checkAjax = null;
                $.each(content, function (index, obj) {

                    //set university name
                    $(".list-pedido").append('<li><a href="#" >'+obj.NombreUniversidad+'</a></li>');
                    //var id_uni = obj.id_universidad;
                    v
                });
            },
            error: function (error) {
                console.log("An error has ocurred while fetching the universities data. " + error.status);
            }
        });
    } catch (e) {
        console.log(e);
    }

}