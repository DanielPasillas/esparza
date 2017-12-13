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
            success: function (content) {
                $(".list-pedido").html('');

                $.each(content, function (index, obj) {

                    //set university name
                    $(".list-pedido").append('<li><a href="#" >' + obj.NombreUniversidad +'</a><ul class="class="rd-navbar-dropdown item-carreer-'+obj.id_universidad+'"></ul></li>');

                    //Get Carreers.
                    $.ajax({
                        url: 'http://localhost:64954/administrator/resources/getCarreersbyuniversity/' + obj.id_universidad,
                        type: 'post',
                        cache: false,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            $.each(response, function (index, cObj) {

                            });
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log("An error has ocurred while fetching the carreers data: " + jqXHR.status);
                        }
                    });
                    
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("An error has ocurred while fetching the universities data: " + jqXHR.status);
            }
        });
    } catch (e) {
        console.log(e);
    }

}