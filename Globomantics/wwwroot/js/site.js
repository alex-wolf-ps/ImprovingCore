// Write your JavaScript code.

$(document).ready(function () {

    $('#employmentLength').change(function () {
        var $option = $(this).find('option:selected');
        if ($option.val() < 3) {
            $('#previousEmployment').slideToggle();
        } else {
            $('#previousEmployment').slideToggle();
        }
    });

})
