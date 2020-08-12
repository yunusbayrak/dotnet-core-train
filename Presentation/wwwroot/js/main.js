$(document).ready(function () {
    $('#sidebarCollapse').on('click', function (event) {
        event.preventDefault();
        $('#sidebar').toggleClass('active');
        var cssClass = $('#i-collapse').attr('class');
        if (cssClass.includes('left')) {
            $('#i-collapse').removeClass('fa-chevron-left');
            $('#i-collapse').addClass('fa-chevron-right');
            $('#sidebarCollapse').attr('title', 'Menüyü Aç');
        } else {
            $('#i-collapse').removeClass('fa-chevron-right');
            $('#i-collapse').addClass('fa-chevron-left');
            $('#sidebarCollapse').attr('title', 'Menüyü Kapat');
        }
    });
});