/*
 Arpateck Inc.
 Unidad: Carreras.js
 Fecha: 12.Diciembre.2017.
 Autor: daniel.pasillas
 Descripción: Aquí se definen los métodos y funciones para el módulo de carreras.
*/

//Main functions container.
$(function () {
    'use strict';

    //Carreers detail.
    $(".detail-carreer").on("click", function (e) {
        e.preventDefault();
        var self = $(this);
        try {

            //loader text.
            $(".modal-container").html('<div style="text-align:center;">Cargando...</div>');
            $.ajax({
                url: 'http://localhost:64954/Administrator/carreras/detail/' + self.attr("data-access-detail"),
                type: 'post',
                cache: false,
                data: {},
                dataType: 'html',
                success: function (response) {
                    //console.log(response);
                    $(".modal-container").html(response);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log("Error while fetching the data. " + jqXHR.status);
                }
            });
        } catch (e) {
            console.log("An error has ocurred.. " + e);
        }
    });
    //------------------------------------------------

    //Carreers deletion.
    $(".delete-carrera").on("click", function (e) {
        e.preventDefault();
        var self = $(this);

        if (confirm("¿Realmente desea eliminar la carrera?"))
        {
            try {
                $.ajax({
                    url: 'http://localhost:64954/Administrator/carreras/delete/' + self.attr("data-access-delete"),
                    type: 'post',
                    data: {},
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (response) {
                        // console.log(result.status);
                        if (response.status)
                        {
                            alert(response.msg);
                            location.reload();
                        }
                        else
                        {
                            alert(response.msg);
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        onsole.log("Error while deleting the carreer. " + jqXHR.status);
                    }
                });
            } catch (e) {
                console.log("An error has ocurred while trying to delete the carreer " + e);
            }
        }
        else
        {
            return;
        }
    });

});