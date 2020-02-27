$(document).ready(function () {
   
    $("#opslaanButton").click(function () {
        var selectedStyleSheet = $("#styleSheetSelect option:selected").val();
        if (selectedStyleSheet == "dark-sb-admin-2") {
            $('body').addClass("switchToDarkBackground");
            $(".loginCard").addClass("switchedToDark");
            setTimeout(function () {
                $("#profile-form").submit();
            }, 1000);
        } else if (isInDarkMode == true)
        {
            $('body').addClass("switchToLightBackground");
            $('.loginCard').addClass("switchedToLight");
            setTimeout(function () {
                $("#profile-form").submit();
            }, 1000);
        }
        else
        {
            $("#profile-form").submit();
        }
    });
});