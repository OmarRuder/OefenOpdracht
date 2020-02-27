//bewerkmodus (v2, bijna af)
$(document).ready(function () {
    tableBody = $('tbody');
    href = $("#deleteResultaatButton").attr("href");
    studentNaam = "";
    vak = "";
    color = "";
    inputFields = "";
    resultaatId = 0;
    cijfer = 0;
    resultatenList = [0];
    var isClickable = false;
    var shouldShow = false;
    var canEdit = false;

    function clickableTableRow(isClickable) {
        if (isClickable) { //wordt aangeroepen door bewerkModus als canEdit true is
            $(tableBody).find('tr').each(function () {
                $(this).addClass("clickable");  //voegt clickable class toe waardoor je rijen kan selecteren
                $(this).click(function () {
                    $(this).find('input[type=checkbox]').click();
                });
            })
        } else {
            $(tableBody).find('tr').each(function () {
                $(this).removeClass("checked").removeClass("clickable"); //verwijdert clickable class (voor stijling)
                $(this).find('input[type=checkbox]').prop("checked", false); //verandert alle checkboxes naar false
                $(this).off('click'); //zet eventhandler click uit zodat je tablerows niet meer klikbaar zijn
            })
        }
    }

    function showContent(shouldShow) { //should show wordt gedefinieerd in bewerkmodus (canEdit), dit bepaalt de content die getoond wordt met bewerkmodus = true
        if (shouldShow) {
            $("#bewerkModusKnop").removeClass('btn-warning').addClass('btn-success'); // verandert de knop naar groen als bewerkmodus aanstaat
            $("#bewerkModusKnop").text("Bewerk Modus uitzetten");
            $(".deleteModalToggler").fadeIn();
            //$('.bewerkModusContent').fadeIn(); checkbox en table head blijven hidden (design keuze)
            $(".beoordeling").hide();
            $(".cijferInput").fadeIn();
        } else {
            $("#bewerkModusKnop").removeClass('btn-success').addClass('btn-warning'); // verandert de knop naar geeel als bewerkmodus uitstaat
            $("#bewerkModusKnop").text("Bewerk Modus aanzetten");
            $("#verwijderRijenKnop").fadeOut();
            $(".deleteModalToggler").fadeOut();
            //$('.bewerkModusContent').fadeOut(); checkbox en table head blijven hidden (design keuze)
            $(".cijferInput").hide();
            $(".beoordeling").slideDown(200);
        }
    }

    function bewerkModus(canEdit) { //can edit wordt bepaald in bewerkmodusknop.click (als class 'on' is roept hij bewerkmodus aan met canEdit = true)
        if (canEdit) {
            clickableTableRow(true); //roept clickabletable row aan met isClickable = true
            showContent(true); //roept showcontent aan met shouldShow = true
        } else {
            clickableTableRow(false);
            showContent(false);
        }
    }

    $("#bewerkModusKnop").click(function () {
        $(this).toggleClass('on'); //togglet of bewerkmodus aanstaat (geeft knop on class of verwijdert deze class)
        if ($(this).hasClass('on')) { //checkt of bewerkmodus aanstaat
            bewerkModus(true); // als bewerkmodus aanstaat wordt bewerkmodus functie aangeroepn met canEdit = true
        } else {
            bewerkModus(false);
        };
    });

    $('.deleteModalToggler').click(function (event) {
        event.preventDefault();
        resultaatId = $(this).attr('resultaat-id');
        console.log(resultaatId + "result id");
        studentNaam = $(this).attr('studentDisplayNaam');
        vak = $(this).attr('vak');
        cijfer = $(this).attr('cijfer');
        $("#deleteResultaatButton").attr("href", href + "/" + resultaatId);
        $("#naamDisplay").text(studentNaam);
        $("#vakDisplay").text(vak);
        $("#beoordelingDisplay").text(cijfer);
        if (parseInt(cijfer) > 5.5) {
            $("#beoordelingDisplay").css('color', 'forestgreen');
        } else {
            $("#beoordelingDisplay").css('color', 'red');
        }
        //$("#resultaatGegevens").html("<dl><dt>Naam</dt><dd>" + studentNaam + "</dd><dt>Vak</dt><dd>" + vak + "</dd><dt>Beoordeling:</dt><dd>" + cijfer + "</dd></dl>");
    });

    $(".checkbox").click(function () { //vult bij elke klik resultatenList met checked items (als er 0 gecheckt zijn gaat verwijder knop automatisch weg)
        tableRow = $(".tableRow-" + $(this).attr('resultaat-id')); //vult tableRow met tablerow-student-id die meegegeven wordt met de checkbox klik
        if ($(this).prop("checked") == true) {
            tableRow.addClass(' checked').removeClass("unchecked");
            //console.log("checked checkbox id: " + $(this).attr('resultaat-id'));
        } else {
            tableRow.removeClass(' checked').addClass('unchecked');
            //console.log("unchecked checkbox id: " + $(this).attr('resultaat-id'));
        };
        resultatenList = $(tableBody).find("tr input[type=checkbox]") //zoekt in tablebody naar alle checkboxen
            .filter(function () { return this.checked; }) //filtert en return alleen aangevinkte checkboxen
            .map(function () {
                return this.getAttribute("resultaat-id"); //returnt van alle aangevinkte checkboxen het attribuut resultaat-id
            })
            .get();
        if (resultatenList.length >= 1) {
            $("#verwijderRijenKnop").fadeIn(); //laat verwijder rijen knop zien als er 1 of meer rijen geselcteerd zijn
            $("#verwijderRijenKnop").text("Verwijder rijen (" + resultatenList.length + ")");
        } else {
            $("#verwijderRijenKnop").fadeOut();
        }
    });

    $('#verwijderRijenKnop').click(function (event) {
        event.preventDefault();
        if (resultatenList.length == 1) {
            $("#verwijderResultatenMessage").text("U staat op het punt om 1 resultaat te verwijderen");
        } else {
            $("#verwijderResultatenMessage").text("U staat op het punt om " + resultatenList.length + " resultaten te verwijderen");
        }
    });

    $("#deleteResultatenButton").click(function () {
        inputFields = ""; // maakt inPut fields eerst leeg om rommel te voorkomen
        for (r = 0; r < resultatenList.length; r++) {
            inputFields += "<input name='resultatenLijst' value='" + resultatenList[r] + "'/>"; //vult inputfields variabele met onzichtbare input fields
        }
        $("#resultatenLijstInput").html(inputFields);
    });

    $(".cijferInput").change(function () {
        cijfer = $(".cijferInput").val(); // stopt cijferinput in variabele

        $(".cijferInput").val(cijfer.replace(".", ",")); // vervangt een punt in input tekst met een komma

        $("#Validation").text(""); // cleart validatie tekst

        if (parseInt(cijfer) > 10) {
            $(".cijferInput").val("10");
            $("#Validation").text("Een cijfer kan niet hoger zijn dan 10");
        }
        else if (parseInt(cijfer) < 1) {
            $(".cijferInput").val("1");
            $("#Validation").text("Een cijfer kan niet lager zijn dan 1");
        }
    });
});