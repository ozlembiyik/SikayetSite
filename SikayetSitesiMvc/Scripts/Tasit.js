$(document).ready(function () {
    $('#TasitTuru').change(function () {
        if ($(this).val() == 0) {
            $('#CabStand').prop("disabled", false);
            $('#PlateNo').prop("disabled",false);
            $('#LineNumber').prop("disabled", true);
          
        }
        else {
            $('#PlateNo').prop("disabled", false);
            $('#LineNumber').prop("disabled", false);
            $('#CabStand').prop("disabled", true);
        }   
    });
});