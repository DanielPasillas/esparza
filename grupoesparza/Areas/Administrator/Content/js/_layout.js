/*
 Arpateck Inc.
 Unidad: _layout.js
 Fecha: 12.Diciembre.2017.
 Autor: daniel.pasillas
 Descripción: Aquí se definen los métodos y funciones para el panel principal - master page.
*/

'use strict';

$(window).load(function () {
    menuPedido();
});


function menuPedido()
{
    try {

        //Ajax call for universities.
        $.ajax({
            url: 'http://localhost:64954/administrator/resources/getuniversities',
            type: 'post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (content) {
                $("#pedidos").html('');
                $.each(content, function (index, obj) {

                    //set university name
                    $("#pedidos").append('<li><a href="#" >' + obj.NombreUniversidad +'</a><ul id="item-carreer-'+obj.id_universidad+'" class="rd-navbar-dropdown"></ul></li>');

                    //Ajax call for carreers.
                    $.ajax({
                        url: 'http://localhost:64954/administrator/resources/getCarreersbyuniversity/' + obj.id_universidad,
                        type: 'post',
                        cache: false,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            $.each(response, function (index, cObj) { //cObj => carreers Object

                                //Fill out the UN component with the CARR items.
                                $("#item-carreer-" + obj.id_universidad).append('<li><a href="#">' + cObj.NombreCarrera + '</a><ul id="item-groups-' + cObj.id_carrera + '" class="rd-navbar-dropdown "></ul></li>');

                                //Ajax call for groups.
                                $.ajax({
                                    url: 'http://localhost:64954/administrator/resources/getgroupsbycarreer/' + cObj.id_carrera,
                                    type: 'post',
                                    cache: false,
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    success: function (data) {
                                        $.each(data, function (index, gObj) { //gObj => groups Object.
                                            $("#item-groups-" + cObj.id_carrera).append('<li>' + gObj.grado + '-' + gObj.grupo + '</li>');
                                        });
                                    },
                                    error: function (jqXHR, textStatus, errorThrown) {
                                        console.log("An error has ocurred while fetching the groups data: " + jqXHR.status);
                                    }
                                });

                            });
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log("An error has ocurred while fetching the carreers data: " + jqXHR.status);
                        }
                    });
                    
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("An error has ocurred while fetching. the universities data: " + jqXHR.status);
            }
        });
    } catch (e) {
        console.log(e);
    }

}