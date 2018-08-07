// Write your JavaScript code.

$(document).ready(function () {

    toggleUi();

    $('#employmentLength').change(function () {
        toggleUi();
    });

    function toggleUi() {
        var $option = $('#employmentLength');
        if ($option.val() < 3) {
            $('#previousEmployment').slideDown();
        } else {
            $('#previousEmployment').slideUp();
        }
    }

})
