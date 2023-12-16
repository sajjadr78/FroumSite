// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Handle button click
    $('#likesModal').on('show.bs.modal', function (e) {
        // Make AJAX request to fetch likes data
        $.ajax({
            url: '/Topics/ShowTopicLikes',  // Replace with your actual endpoint
            type: 'GET',
            success: function (data) {
                // Update the likesContainer with the fetched data
                $('#likesContainer').html(data);
            },
            error: function () {
                // Handle error
                console.error('Failed to fetch likes data.');
            }
        });
    });

});