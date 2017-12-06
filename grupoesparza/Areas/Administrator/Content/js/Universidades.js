/*
 Arpateck Inc.
 Unidad: Universidades.js
 Autor: daniel.pasillas
 Descripción: Aquí se definen los métodos y funciones para el módulo de universidades.
*/

$(function () {

    'use strict';

    //Event Add, show form university.
    $(".add-university").one("click", function () {

        try {

            $.ajax({
                url:  'http://localhost:64954/Administrator/universidades/nueva',
                type: 'post',
                cache: false,
                data: {},
                dataType: 'html',
                success: function (content) {
                    $("#form-container").html(content);
                },
                error: function (error) {
                    console.log(error.status);
                }
            });

        } catch (e) {
            console.log("An exception has ocurred" + e);
        }

    });
    //---------------------------------------------

    //Delete university. It only disable the record.
    $(".table-university").on("click", ".delete-university", function () {
        if (confirm("¿Realmente desea eliminar la Universidad?"))
        {
            try {

                var self = $(this);

                $.ajax({
                    url: 'http://localhost:64954/Administrator/universidades/delete?id=' + self.attr('data-id-uni'),
                    type: 'post',
                    cache: false,
                    success: function (response) {
                        var request = JSON.parse(response);
                        console.log(console.response);
                    },
                    error: function (error) {
                        console.log("An error has ocurred " + error);
                    }
                });

            } catch (e) {
                console.log(e);
            }
        }
        else {
            return;
        }
    });
   //---------------------------------------------

    //show edit form for university.
    $(".table-university").on("click", ".edit-university", function () {
        try {

            var self = $(this);

            $.ajax({
                url: 'http://localhost:64954/Administrator/universidades/edit?id=' + self.attr('data-id-uni'),
                type: 'post',
                dataType: 'html',
                data:{},
                cache: false,
                success: function (response) {
                    $("#form-container").html(response);
                },
                error: function (error) {
                    console.log("An error has ocurred " + error);
                }
            });

        } catch (e) {
            console.log(e);
        }
    });
    //---------------------------------------------
});