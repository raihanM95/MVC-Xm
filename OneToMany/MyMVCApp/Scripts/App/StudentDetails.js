$('#District').change(function() {
        var districtDD = $('#District');
        var distId = districtDD.val();

        var jsonData = {districtId: distId };



        // ajax request to student/getbydistrict

        $.ajax(
            {
                url: "/student/getbydistrict",
                type: "POST",
                data: jsonData,
                success: function(students) {

                    var studentDD = $('#Student');

                    $('#Student').empty();

                    $('#Student').append('<option>Select...</option>');

                    $.each(students,
                        (key, student) => {
                            var option = "<option value='" + student.ID + "'>" + student.Name + "</option>";
                            studentDD.append(option);
                        });


                },
                error: function(response){
                    alert(response);
                }

            }
        );
    });

$('#Student').change(function() {
    var studentId = $('#Student').val();

    var jsonData = {studentId: studentId };

    $.ajax({
        url: "/student/GetStudentDetailsPartial",
        type: "GET",
        data: jsonData,

        success: (studentDetailsPartial) => {
            $('#divStudentInfo').empty();
            $('#divStudentInfo').append(studentDetailsPartial);
        }

    });

});



