
$('[data-toggle="toggle"]').click(function () {
    var selector = $(this).data('target');

    $('.slider').removeClass('in');
    $('.slider').addClass('white');
    $(selector).toggleClass('in');
    $(selector).removeClass('white');
});


