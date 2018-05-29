
//A toggle class that appends "in" to set a Lifestyle panel to being in focus
//or appends "white" if they are closing to ensure things look clean in motion.
$('[data-toggle="toggle"]').click(function () {
    var selector = $(this).data('target');

    $('.slider').removeClass('in');
    $('.slider').addClass('white');
    $(selector).toggleClass('in');
    $(selector).removeClass('white');
});


