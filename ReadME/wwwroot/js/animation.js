$(window).on('load', function () {
    $('header ul a .hover').width(0);
    $('header ul a .active').width($("header ul a .active").siblings('li').width());
    if ($(window).width() < 1000) 
    {
        $("nav ul.MasterNav a ").css("color","#fff");
    }
    
});
$(document).ready(function () {
   
    
    $('header ul a').hover(function () {
       
        if ($(window).width() > 1000) {
            $('header ul a').css('color', '#d6d6d6');
            $(this).css('color', '#000');
            $('.free-nav span').css("color", "#fff");

            $('.hover').width(0);
            $(this).children('.hover').width($(this).children('li').width());
        }
    })
    $('header ul a').on('mouseleave', function () {
        if ($(window).width() > 1000) {

            $('header ul a').css('color', '#000');
            $('header ul a .hover').width(0);
            $('header ul a .active').width($("header ul a .active").siblings('li').width());
            $('header .free-nav span').css('color', '#fff');
        }
    });




    $('.more button').on('click', function () {



        $(this).toggleClass('more-white');
        $(this).parent().siblings(".card-layer").toggleClass('show-more');
        $(this).parent().siblings(".more-options").toggleClass('show-more');
    });

    $('.mobile-menu').on('click', function () {
        $('.main-menu nav').css('display', 'block');
        $(".close-nav").css('display', 'block');
    });


    $('.close-nav').on('click', function () {
        $('.main-menu nav').css('display', 'none');
    });


    // search bar
    $(".search-bar input").on("input",function(){
        $(".search-bar a").attr("href","?search="+$(this).val());
    });


    //category and sort bar

    $(".admin-category-sub-header button").on('click', function () {

       
        var catsort = "";

        if ($(".sort-by-cat input").val().length > 0) {
            catsort += "?category=" + $(".sort-by-cat input").val();
        }
      


        if (catsort.length > 0) {

            window.location.href = catsort;
        }


    });


    $(".sub-header button").on('click', function () {
        var catsort = "";

        if ($(".sort-by-cat input").val().length > 0) {
            catsort += "?category=" + $(".sort-by-cat input").val();
        }

        if ($(".sort-by input").val().length > 0) {
            if (catsort.length > 0) {
                catsort += "&sort=" + $(".sort-by input").val();
            }
            else {
                catsort += "?sort=" + $(".sort-by input").val();
            }
        }

        if (catsort.length > 0) {

            window.location.href = catsort;
        }


    });

    $(".admin-sub-header button").on('click', function () {
        var catsort = "/admin";

        if ($(".sort-by-cat input").val().length > 0) {
            catsort += "?table=" + $(".sort-by-cat input").val();
        }

        if ($(".sort-by input").val().length > 0) {
            if (catsort.length > 0) {
                catsort += "&id=" + $(".sort-by input").val();
            }
           
        }

        if (catsort.length > 0) {

            window.location.href = catsort;
        }


    });





    // Message Animation

    $(".success-message button").on('click', function () {
        $(this).parent("div").css("margin-top", "-200px");
    });

    $(".error-message button").on('click', function () {
        $(this).parent("div").css("margin-top", "-200px");
    });


    // Login and SignUp

    $('.signupButton').on('click', function () {
        $(this).css({ 'color': '#070e69', 'font-weight': '500' });
        $('.loginButton').css({ 'color': '#78777a', 'font-weight': '400' });
        $('.loginForm').css('display', 'none');
        $('.signupForm').css('display', 'block');
    });

    $('.loginButton').on('click', function () {
        $(this).css({ 'color': '#070e69', 'font-weight': '500' });
        $('.signupButton').css({ 'color': '#78777a', 'font-weight': '400' });
        $('.signupForm').css('display', 'none');
        $('.loginForm').css('display', 'block');
    });


    $('.logo').click(function () {
        $(this).siblings('input').attr('type', 'text');
        $(this).css('display', 'none');
        $(this).siblings('.offLogo').css('display', 'block');
    });
    $('.offLogo').click(function () {
        $(this).siblings('input').attr('type', 'password');
        $(this).css('display', 'none');
        $(this).siblings('.logo').css('display', 'block');
    });


    // login validation

    /*
    
    $('selector').on('event',function()
    {
            statements
    });

     */

    $("#newLogin").on('submit', function () {
       
      
        var logEmail = $("#log-email").val();
       
        var password = $("#password").val();
        var isEmailValid = true;
        var isPasswordValid = true;
       
          if (!logEmail.match(/^[^\s@]+@[^\s@]+$/))
          {
            $('#log-emailLabel').html("Invalid email address");
            $('#log-emailLabel').css('color', 'red');
            isEmailValid = false;

        }
        else {
            $('#log-emailLabel').html("E-mail Address");
            $('#log-emailLabel').css('color', '#494949');
            isEmailValid = true;

        }

        if (password.length < 8) {
            $('#passwordLabel').html("Password must have atleast 8 char");
            $('#passwordLabel').css('color', 'red');
            isPasswordValid = false;

        }
        else {
            $('#passwordLabel').html("Password");
            $('#passwordLabel').css('color', '#494949');
            isPasswordValid = true;

        }

        
        return isPasswordValid && isEmailValid;

    });

    $("#form-signup").on('submit', function () {
        var regUsername = $('#reg-username').val();
        var regEmail = $("#reg-email").val();
        var regPassword = $("#reg-password").val();
        var regConfpass = $("#reg-confpass").val();
        var isUsernameValid = true;
        var isEmailValid = true;
        var isPasswordValid = true;
        var isConfPassValid = true;

        if (regUsername.length < 4) {
            $('#reg-usernameLabel').html("Username must have atleast 4 char");
            $('#reg-usernameLabel').css('color', 'red');
            isUsernameValid = false;
        }
        else {
            $('#reg-usernameLabel').html("Username");
            $('#reg-usernameLabel').css('color', '#494949');
            isUsernameValid = true;
        }

        if (regPassword.length < 8) {
            $('#reg-passwordLabel').html("Password must have atleast 8 char");
            $('#reg-passwordLabel').css('color', 'red');
            isPasswordValid = false;

        }
        else {
            $('#reg-passwordLabel').html("Password");
            $('#reg-passwordLabel').css('color', '#494949');
            isPasswordValid = true;

        }

        if (regPassword != regConfpass) {
            $('#reg-confpassLabel').html("Password is not matching");
            $('#reg-confpassLabel').css('color', 'red');
            isConfPassValid = false;

        }
        else {
            $('#reg-confpassLabel').html("Confirm Password");
            $('#reg-confpassLabel').css('color', '#494949');
            isConfPassValid = true;

        }

// email match with regular expression
        if (!regEmail.match(/^[^\s@]+@[^\s@]+$/)) {
            $('#reg-emailLabel').html("Invalid email address");
            $('#reg-emailLabel').css('color', 'red');
            isEmailValid = false;

        }
        else {
            $('#reg-emailLabel').html("E-mail Address");
            $('#reg-emailLabel').css('color', '#494949');
            isEmailValid = true;

        }




        return isUsernameValid && isEmailValid && isPasswordValid && isConfPassValid;

    });



    $("#form-forgotpassword").on('submit', function () {

        var fpEmail = $("#fp-input").val();
        var isFpEmailValid = true;

        if (!fpEmail.match(/^[^\s@]+@[^\s@]+$/)) {
            $('#fp-emailLabel').html("Invalid email address");
            $('#fp-emailLabel').css('color', 'red');
            isFpEmailValid = false;

        }
        else {
            $('#fp-emailLabel').html("E-mail Address");
            $('#fp-emailLabel').css('color', '#494949');
            isFpEmailValid = true;

        }


        return isFpEmailValid;

    });




    // OTP Verification


    $("#otp-1").on('input', function (e) {
        $(this).val("");
        OTPValidation();
        $(this).val(e.originalEvent.data);
        if ($(this).val().length == 1) {
            $("#otp-2").focus();
            OTPValidation();
        }

    });

    $("#otp-2").on('input', function (e) {
        $(this).val("");
        OTPValidation();
        $(this).val(e.originalEvent.data);
        if ($(this).val().length == 1) {
            $("#otp-3").focus();
            OTPValidation();
        }
    });

    $("#otp-3").on('input', function (e) {
        $(this).val("");
        OTPValidation();
        $(this).val(e.originalEvent.data);
        if ($(this).val().length == 1) {
            $("#otp-4").focus();
            OTPValidation();
        }
    });

    $("#otp-4").on('input', function (e) {
        $(this).val("");
        OTPValidation();
        $(this).val(e.originalEvent.data);
        if ($(this).val().length == 1) {
            $("#otp-5").focus();
            OTPValidation();
        }
    });

    $("#otp-5").on('input', function (e) {
        $(this).val("");
        OTPValidation();
        $(this).val(e.originalEvent.data);
        if ($(this).val().length == 1) {
            $("#otp-6").focus();
            OTPValidation();
        }
    });

    $("#otp-6").on('input', function (e) {
        $(this).val("");
        OTPValidation();
        $(this).val(e.originalEvent.data);
        if ($(this).val().length == 1) {
            $("#otp-6").blur();

            OTPValidation();
        }
    });


    function OTPValidation() {
        if ($("#otp-1").val().length > 0 && $("#otp-2").val().length > 0 && $("#otp-3").val().length > 0 &&
            $("#otp-4").val().length > 0 && $("#otp-5").val().length > 0 && $("#otp-6").val().length > 0) {


            $(".otp-verify-btn").removeAttr("disabled");
            $(".otp-verify-btn").css("background", "#36128a");
            $(".otp-verify-btn").css("cursor", "pointer");
        }
        else {
            $(".otp-verify-btn").attr("disabled", "true");
            $(".otp-verify-btn").css("background", "#36128a4b");
            $(".otp-verify-btn").css("cursor", "not-allowed");
        }
    }

    // Timer

    var currentVal = 25;
    var timer25 = setInterval(timer, 1000);

    function timer() {
        if (currentVal == 0) {
            $(".otp-resend p").css("display", "none");
            $(".otp-resend a").css("display", "block");
            timer25.clearInterval;

        }
        currentVal--;
        $("#timer25").html(currentVal);
    }

    var min = 4;
    var sec = 59;

    var timer5min = setInterval(timerPro, 1000);

    function timerPro() {
        if (sec == 0) {
            if (min == 0) {
                $(".main-timer").html("<i class='fa fa-ban' style='font-size:24px;color:red;'></i>");
                $(".otp input").attr('disabled', 'true');
                $(".otp input").css('border', 'none');
                $(".otp input").css('background', '#cecece');
                timer5min.clearInterval;
            }
            min--;
            if (min == 0) {
                $("#min, #sec").css('color', 'red');
            }
            $("#min").html(min);
            sec = 60;
        }
        sec--;
        $("#sec").html(sec);
    }



    // Change Password

    $("#form-changepass").on('submit', function () {

        var regPassword = $("#reg-password").val();
        var regConfpass = $("#reg-confpass").val();

        var isPasswordValid = true;
        var isConfPassValid = true;



        if (regPassword.length < 8) {
            $('#reg-passwordLabel').html("Password must have atleast 8 char");
            $('#reg-passwordLabel').css('color', 'red');
            isPasswordValid = false;

        }
        else {
            $('#reg-passwordLabel').html("Password");
            $('#reg-passwordLabel').css('color', '#494949');
            isPasswordValid = true;

        }

        if (regPassword != regConfpass) {
            $('#reg-confpassLabel').html("Password is not matching");
            $('#reg-confpassLabel').css('color', 'red');
            isConfPassValid = false;

        }
        else {
            $('#reg-confpassLabel').html("Confirm Password");
            $('#reg-confpassLabel').css('color', '#494949');
            isConfPassValid = true;

        }







        return isPasswordValid && isConfPassValid;

    });



    // Profile hover Show some extra Menu

    $("a.profileLink").click(function () {
        $(".ProfileNav").toggleClass("SubNavShow");
    })

    $(".ProfileNav").on('mouseleave', function () {
        $(".ProfileNav").toggleClass("SubNavShow");
    })


    // Edit profile

    $(".profile-edit").click(function () {
        $(".profile-name input").removeAttr('readonly').focus();
        $(".profile-email input").removeAttr('readonly');
        $(".edit-pen").css('display', 'none');
        $(".edit-plane").css('display', 'block');
    });



    // Upload 

    $("#up-main-cat").on("change", function () {
        $("#sub-cat").attr('list', 'up-catList-' + $(this).val())
    });


    // Upload Book form Validation

    $("#form-upload-book").on('submit', function () {
        var upBookName = $("#up-name").val();
        var upAuthor = $("#up-author").val();
        var upDesc = $("#reg-textarea").val();
        var upLang = $("#up-main-lang").val();
        var upCat = $("#up-main-cat").val();
        var upPrice = $("#up-price").val();
        var upFile = $("#up-book-file").val();


        var isValidUpBookName = true;
        var isValidUpAuthor = true;
        var isValidUpDesc = true;
        var isValidUpCat = true;
        var isValidUpPrice = true;
        var isValidFile = true;
        var isLang = true;

        if (upBookName.length > 40 || upBookName.length < 5) {
            $('#up-nameLabel').html("Book name should have 5 to 40 Char");
            $('#up-nameLabel').css("color", "red");
            isValidUpBookName = false;
        }
        else {
            $('#up-nameLabel').html("Name");
            $('#up-nameLabel').css('color', '#494949');
            isValidUpBookName = true;
        }

        if (upAuthor.length > 20 || upAuthor.length < 5) {
            $('#up-authorLabel').html("Author name should have 5 to 20 Char");
            $('#up-authorLabel').css("color", "red");
            isValidUpAuthor = false;
        }
        else {
            $('#up-authorLabel').html("Author");
            $('#up-authorLabel').css('color', '#494949');
            isValidUpAuthor = true;
        }

        if (upDesc.length > 100 || upDesc.length < 10) {
            $('#reg-textareaLabel').html("Description should have 10 to 100 Char");
            $('#reg-textareaLabel').css("color", "red");
            isValidUpDesc = false;
        }
        else {
            $('#reg-textareaLabel').html("Description");
            $('#reg-textareaLabel').css('color', '#494949');
            isValidUpDesc = true;
        }

        if (upCat.length < 2) {
            $('#up-main-catLabel').html("Select valid Category");
            $('#up-main-catLabel').css("color", "red");
            isValidUpCat = false;
        }
        else {
            $('#up-main-catLabel').html("Category");
            $('#up-main-catLabel').css("color", "#494949");
            isValidUpCat = true;
        }

        if (upLang.length < 2) {
            $('#up-main-langLabel').html("Select valid Language");
            $('#up-main-langLabel').css("color", "red");
            isLang = false;
        }
        else {
            $('#up-main-langLabel').html("Language");
            $('#up-main-langLabel').css("color", "#494949");
            isLang = true;
        }


        if (Number(upPrice) < 1) {
            $('#up-priceLabel').html("Enter valid Price");
            $('#up-priceLabel').css("color", "red");
            isValidUpPrice = false;
        }
        else {
            $('#up-priceLabel').html("Price");
            $('#up-priceLabel').css("color", "#494949");
            isValidUpPrice = true;
        }

        if (upFile.endsWith('.pdf')) {
            $('#up-book-file-label').html("");
            isValidFile = true;
        }
        else {
            $('#up-book-file-label').css("color", "red");
            $('#up-book-file-label').html("Please select PDF file.");
            isValidFile = false;
        }

        return isLang && isValidUpBookName && isValidUpAuthor && isValidUpDesc && isValidUpCat && isValidUpPrice && isValidFile;

    });



    $("#form-upload-free-book").on('submit', function () {
        var upBookName = $("#up-name").val();
        var upAuthor = $("#up-author").val();
        var upDesc = $("#reg-textarea").val();
        var upLang = $("#up-main-lang").val();
        var upCat = $("#up-main-cat").val();
        var upFile = $("#up-book-file").val();


        var isValidUpBookName = true;
        var isValidUpAuthor = true;
        var isValidUpDesc = true;
        var isValidUpCat = true;
        var isValidFile = true;
        var isLang = true;

        if (upBookName.length > 40 || upBookName.length < 5) {
            $('#up-nameLabel').html("Book name should have 5 to 40 Char");
            $('#up-nameLabel').css("color", "red");
            isValidUpBookName = false;
        }
        else {
            $('#up-nameLabel').html("Name");
            $('#up-nameLabel').css('color', '#494949');
            isValidUpBookName = true;
        }
        if (upLang.length < 2) {
            $('#up-main-langLabel').html("Select valid Language");
            $('#up-main-langLabel').css("color", "red");
            isLang = false;
        }
        else {
            $('#up-main-langLabel').html("Language");
            $('#up-main-langLabel').css("color", "#494949");
            isLang = true;
        }
        if (upAuthor.length > 20 || upAuthor.length < 5) {
            $('#up-authorLabel').html("Author name should have 5 to 20 Char");
            $('#up-authorLabel').css("color", "red");
            isValidUpAuthor = false;
        }
        else {
            $('#up-authorLabel').html("Author");
            $('#up-authorLabel').css('color', '#494949');
            isValidUpAuthor = true;
        }

        if (upDesc.length > 100 || upDesc.length < 10) {
            $('#reg-textareaLabel').html("Description should have 10 to 100 Char");
            $('#reg-textareaLabel').css("color", "red");
            isValidUpDesc = false;
        }
        else {
            $('#reg-textareaLabel').html("Description");
            $('#reg-textareaLabel').css('color', '#494949');
            isValidUpDesc = true;
        }

        if (upCat.length < 2) {
            $('#up-main-catLabel').html("Select valid Category");
            $('#up-main-catLabel').css("color", "red");
            isValidUpCat = false;
        }
        else {
            $('#up-main-catLabel').html("Category");
            $('#up-main-catLabel').css("color", "#494949");
            isValidUpCat = true;
        }



        if (upFile.endsWith('.pdf')) {
            $('#up-book-file-label').html("");
            isValidFile = true;
        }
        else {
            $('#up-book-file-label').css("color", "red");
            $('#up-book-file-label').html("Please select PDF file.");
            isValidFile = false;
        }



        return isLang && isValidUpBookName && isValidUpAuthor && isValidUpDesc && isValidUpCat && isValidFile;

    });





    $("#form-upload-free-course").on('submit', function () {
       
        var upBookName = $("#up-name").val();
        var upDesc = $("#reg-textarea").val();
        var upLang = $("#up-main-lang").val();
        var upSource = $("#up-main-source").val();
        var upCat = $("#up-main-cat").val();
        var upURL = $("#up-course-url").val();


        var isValidUpBookName = true;
        var isValidUpDesc = true;
        var isValidUpCat = true;
        var isValidURL = true;
        var isLang = true;
        var isSource = true;

        if (upBookName.length > 40 || upBookName.length < 5) {
            $('#up-nameLabel').html("Course name should have 5 to 40 Char");
            $('#up-nameLabel').css("color", "red");
            isValidUpBookName = false;
        }
        else {
            $('#up-nameLabel').html("Name");
            $('#up-nameLabel').css('color', '#494949');
            isValidUpBookName = true;
        }

        

        if (upDesc.length > 100 || upDesc.length < 10) {
            $('#reg-textareaLabel').html("Description should have 10 to 100 Char");
            $('#reg-textareaLabel').css("color", "red");
            isValidUpDesc = false;
        }
        else {
            $('#reg-textareaLabel').html("Description");
            $('#reg-textareaLabel').css('color', '#494949');
            isValidUpDesc = true;
        }

        if (upCat.length < 2) {
            $('#up-main-catLabel').html("Select valid Category");
            $('#up-main-catLabel').css("color", "red");
            isValidUpCat = false;
        }
        else {
            $('#up-main-catLabel').html("Category");
            $('#up-main-catLabel').css("color", "#494949");
            isValidUpCat = true;
        }
        if (upSource.length < 2) {
            $('#up-main-sourceLabel').html("Select valid Source");
            $('#up-main-sourceLabel').css("color", "red");
            isSource = false;
        }
        else {
            $('#up-main-sourceLabel').html("Source");
            $('#up-main-sourceLabel').css("color", "#494949");
            isSource = true;
        }

        if ((upURL.startsWith('https://') || upURL.startsWith('http://') || upURL.startsWith('www') || upURL.includes('www.')) && upURL.length > 8) {

            $('#up-course-urlLabel').html("URL");
            $('#up-course-urlLabel').css("color", "#494949");
            isValidURL = true;

        }
        else {

            $('#up-course-urlLabel').html("Invalid URL");
            $('#up-course-urlLabel').css("color", "red");
            isValidURL = false;
        }
        if (upLang.length < 2) {
            $('#up-main-langLabel').html("Select valid Language");
            $('#up-main-langLabel').css("color", "red");
            isLang = false;
        }
        else {
            $('#up-main-langLabel').html("Language");
            $('#up-main-langLabel').css("color", "#494949");
            isLang = true;
        }

      

        return isLang && isSource && isValidUpBookName && isValidUpDesc && isValidUpCat && isValidURL;

    });


    // Credit card or debit card animation

    try {
        $(".gw-cn-one").focus();
    }
    catch (error) {

    }

    $(".gw-cn-one").on('input', function (e) {


        if ($(this).val().length == 4) {
            $(".gw-cn-two").focus();

        }

    });

    $(".gw-cn-two").on('input', function (e) {


        if ($(this).val().length == 4) {
            $(".gw-cn-three").focus();

        }

    });
    $(".gw-cn-three").on('input', function (e) {


        if ($(this).val().length == 4) {
            $(".gw-cn-four").focus();

        }

    });

    $(".gw-cn-four").on('input', function (e) {


        if ($(this).val().length == 4) {
            $(".gw-ce-date").focus();

        }

    });
    $(".gw-ce-date").on('input', function (e) {
        if ($(this).val().length == 1) {
            try {
                if (Number($(this).val()) > 1) {

                    $(".gw-card-expire label").html("invalid thru").css("color", "red");
                }
                else {

                    $(".gw-card-expire label").html("valid thru").css("color", "#aaa9a9");
                }

            }
            catch (error) {
              
                $(".gw-card-expire label").html("invalid thru").css("color", "red");
            }

        }

        if ($(this).val().length == 2) {
            try {
                if (Number($(this).val() > 12)) {
                    $(".gw-card-expire label").html("invalid thru").css("color", "red");
                }
                else {
                    $(".gw-card-expire label").html("valid thru").css("color", "#aaa9a9");
                    $(this).val($(this).val() + "/");
                }

            }
            catch (error) {
                $(".gw-card-expire label").html("invalid thru").css("color", "red");
            }


        }

        if ($(this).val().length == 5) {
            if (Number($(this).val().split("/")[1]) < 22) {
                $(this).val($(this).val().split("/")[0] + "/");
                $(".gw-card-expire label").html("invalid thru").css("color", "red");
            }
            else if ($(".gw-cn-one").val().length != 4 || $(".gw-cn-two").val().length != 4 || $(".gw-cn-three").val().length != 4 || $(".gw-cn-four").val().length != 4) {
                $(".gw-card-expire label").html("valid thru").css("color", "#aaa9a9");
            }
            else {
                $(".gw-card-expire label").html("valid thru").css("color", "#aaa9a9");

                setTimeout(function () {
                    $(".gw-card").css('transform', 'rotateY(180deg)');
                    $(".gw-card-front").css('display', 'none');
                    $(".gw-card-back").css('display', 'block');
                    $(".gw-card-back div").css('visibility', 'hidden');
                },
                    100);
                setTimeout(function () {
                    $(".gw-card-back div").css('visibility', 'visible');
                    $(".gw-cvv input").focus();

                },
                    500);
            }




        }

    });

    $(".gw-cvv input").on("input", function () {
        if ($(this).val().length == 3) {
            $("#cardPaymentForm").submit();
            $(".gw-cvv input").blur();
        }
    });

    $("#gw-upi-form").on("submit", function () {
        try {
            if ($("#gw-upi-form input").val().split("@")[0].length > 0 && $("#gw-upi-form input").val().split("@")[1].length > 0) {
                return true;
            }
            else {
                return false;
            }
        }
        catch (error) {


            return false;
        }

    });

    $("#gw-bank-form").on("submit", function () {
        if ($(".gw-bank-number").val().length > 10 && $(".gw-bank-ifsc").val().length > 4) {
            return true;
        }
        return false;
    });



    // Textarea count and validation

    $(".report-form .textarea-holder textarea").on("input", function () {
        $(".textarea-len").html($(this).val().length);
        if ($(this).val().length > 200 || $(this).val().length == 0 || $(this).val().trim() == "") {
            $(".report-form button").css("opacity", "0").css("cursor", "not-allowed");
            $(".report-form button").attr("disabled", "true");
            $(".textarea-len").css("color", "red");
        }
        else {
            $(".report-form button").css("opacity", "1").css("cursor", "pointer");
            $(".textarea-len").css("color", "#159704");
            $(".report-form button").removeAttr("disabled");
        }
    });

    $("#user-report-form").on("submit", function () {
        if ($("#user-report-form input").val().length == 0 || $("#user-report-form textarea").val().length == 0) {
            return false;
        }
        else {
            return true;
        }
    });




    $(".ticket-form .textarea-holder textarea").on("input", function () {
        $(".textarea-len").html($(this).val().length);
        if ($(this).val().length > 500 || $(this).val().length == 0 || $(this).val().trim() == "") {
            $(".ticket-form button").css("opacity", "0").css("cursor", "not-allowed");
            $(".ticket-form button").attr("disabled", "true");
            $(".textarea-len").css("color", "red");
        }
        else {
            $(".ticket-form button").css("opacity", "1").css("cursor", "pointer");
            $(".ticket-form button").removeAttr("disabled");
            $(".textarea-len").css("color", "#159704");

        }
    });

    $("#user-ticket-form").on("submit", function () {
        if ($("#user-ticket-form textarea").val().length == 0) {
            return false;
        }
        else {
            return true;
        }
    });

    $(".sug-options span").on('click', function () {


        if ($(this).hasClass("sug-choosed")) {
            $(this).css("background", "#a879f3");
            $(this).removeClass("sug-choosed");
            $("#form-editSuggestion textarea").val($("#form-editSuggestion textarea").val().replace("|" + $(this).html(), ""));
        }
        else {
            $(this).css("background", "#4e0d99");
            $(this).addClass("sug-choosed");
            $("#form-editSuggestion textarea").val($("#form-editSuggestion textarea").val() + "|" + $(this).html());
        }

        if ($("#form-editSuggestion textarea").val().length > 0) {
            $(".save-editButton button").css("visibility", "visible").css("opacity", "1");
        }
        else {
            $(".save-editButton button").css("opacity", "0").css("visibility", "hidden");
        }



    });



    //  Edit book upload

    
    $("#edit-form-upload-book").on('submit', function () {
        var upBookName = $("#up-name").val();
        var upAuthor = $("#up-author").val();
       
        var upLang = $("#up-main-lang").val();
        var upCat = $("#up-main-cat").val();
        var upPrice = $("#up-price").val();
        


        var isValidUpBookName = true;
        var isValidUpAuthor = true;
      
        var isValidUpCat = true;
        var isValidUpPrice = true;
     
        var isLang = true;

        if (upBookName.length > 40 || upBookName.length < 5) {
            $('#up-nameLabel').html("Book name should have 5 to 40 Char");
            $('#up-nameLabel').css("color", "red");
            isValidUpBookName = false;
        }
        else {
            $('#up-nameLabel').html("Name");
            $('#up-nameLabel').css('color', '#494949');
            isValidUpBookName = true;
        }

        if (upAuthor.length > 20 || upAuthor.length < 5) {
            $('#up-authorLabel').html("Author name should have 5 to 20 Char");
            $('#up-authorLabel').css("color", "red");
            isValidUpAuthor = false;
        }
        else {
            $('#up-authorLabel').html("Author");
            $('#up-authorLabel').css('color', '#494949');
            isValidUpAuthor = true;
        }

       

        if (upCat.length < 2) {
            $('#up-main-catLabel').html("Select valid Category");
            $('#up-main-catLabel').css("color", "red");
            isValidUpCat = false;
        }
        else {
            $('#up-main-catLabel').html("Category");
            $('#up-main-catLabel').css("color", "#494949");
            isValidUpCat = true;
        }

        if (upLang.length < 2) {
            $('#up-main-langLabel').html("Select valid Language");
            $('#up-main-langLabel').css("color", "red");
            isLang = false;
        }
        else {
            $('#up-main-langLabel').html("Language");
            $('#up-main-langLabel').css("color", "#494949");
            isLang = true;
        }


        if (Number(upPrice) < 1) {
            $('#up-priceLabel').html("Enter valid Price");
            $('#up-priceLabel').css("color", "red");
            isValidUpPrice = false;
        }
        else {
            $('#up-priceLabel').html("Price");
            $('#up-priceLabel').css("color", "#494949");
            isValidUpPrice = true;
        }


        return isLang && isValidUpBookName && isValidUpAuthor && isValidUpCat && isValidUpPrice;

    });



    $("#edit-form-upload-free-book").on('submit', function () {
        var upBookName = $("#up-name").val();
        var upAuthor = $("#up-author").val();
       
        var upLang = $("#up-main-lang").val();
        var upCat = $("#up-main-cat").val();
        

        var isValidUpBookName = true;
        var isValidUpAuthor = true;
      
        var isValidUpCat = true;
      
        var isLang = true;

        if (upBookName.length > 40 || upBookName.length < 5) {
            $('#up-nameLabel').html("Book name should have 5 to 40 Char");
            $('#up-nameLabel').css("color", "red");
            isValidUpBookName = false;
        }
        else {
            $('#up-nameLabel').html("Name");
            $('#up-nameLabel').css('color', '#494949');
            isValidUpBookName = true;
        }
        if (upLang.length < 2) {
            $('#up-main-langLabel').html("Select valid Language");
            $('#up-main-langLabel').css("color", "red");
            isLang = false;
        }
        else {
            $('#up-main-langLabel').html("Language");
            $('#up-main-langLabel').css("color", "#494949");
            isLang = true;
        }
        if (upAuthor.length > 20 || upAuthor.length < 5) {
            $('#up-authorLabel').html("Author name should have 5 to 20 Char");
            $('#up-authorLabel').css("color", "red");
            isValidUpAuthor = false;
        }
        else {
            $('#up-authorLabel').html("Author");
            $('#up-authorLabel').css('color', '#494949');
            isValidUpAuthor = true;
        }

       

        if (upCat.length < 2) {
            $('#up-main-catLabel').html("Select valid Category");
            $('#up-main-catLabel').css("color", "red");
            isValidUpCat = false;
        }
        else {
            $('#up-main-catLabel').html("Category");
            $('#up-main-catLabel').css("color", "#494949");
            isValidUpCat = true;
        }



       



        return isLang && isValidUpBookName && isValidUpAuthor && isValidUpCat;

    });





    $("#edit-form-upload-free-course").on('submit', function () {
        var upBookName = $("#up-name").val();
       
        var upLang = $("#up-main-lang").val();
        var upSource = $("#up-main-source").val();
        var upCat = $("#up-main-cat").val();
        var upURL = $("#up-course-url").val();


        var isValidUpBookName = true;
      
        var isValidUpCat = true;
        var isValidURL = true;
        var isLang = true;
        var isSource = true;

        if (upBookName.length > 40 || upBookName.length < 5) {
            $('#up-nameLabel').html("Course name should have 5 to 40 Char");
            $('#up-nameLabel').css("color", "red");
            isValidUpBookName = false;
        }
        else {
            $('#up-nameLabel').html("Name");
            $('#up-nameLabel').css('color', '#494949');
            isValidUpBookName = true;
        }

        if (upCat.length < 2) {
            $('#up-main-catLabel').html("Select valid Category");
            $('#up-main-catLabel').css("color", "red");
            isValidUpCat = false;
        }
        else {
            $('#up-main-catLabel').html("Category");
            $('#up-main-catLabel').css("color", "#494949");
            isValidUpCat = true;
        }

        if (upSource.length < 2) {
            $('#up-main-sourceLabel').html("Select valid Source");
            $('#up-main-sourceLabel').css("color", "red");
            isSource = false;
        }
        else {
            $('#up-main-sourceLabel').html("Source");
            $('#up-main-sourceLabel').css("color", "#494949");
            isSource = true;
        }

        if ((upURL.startsWith('https://') || upURL.startsWith('http://') || upURL.startsWith('www') || upURL.includes('www.')) && upURL.length > 8) {

            $('#up-course-urlLabel').html("URL");
            $('#up-course-urlLabel').css("color", "#494949");
            isValidURL = true;

        }
        else {

            $('#up-course-urlLabel').html("Invalid URL");
            $('#up-course-urlLabel').css("color", "red");
            isValidURL = false;
        }
        if (upLang.length < 2) {
            $('#up-main-langLabel').html("Select valid Language");
            $('#up-main-langLabel').css("color", "red");
            isLang = false;
        }
        else {
            $('#up-main-langLabel').html("Language");
            $('#up-main-langLabel').css("color", "#494949");
            isLang = true;
        }

       


        return isLang && isSource && isValidUpBookName  && isValidUpCat && isValidURL;

    });



    //  Share button logic

    $(".more-options button").on('click',function(){
        
        var Shortlink=$(this).parents(".more-options").siblings(".book-checkout").children("a").attr('href');
        var link="https://localhost:5001"+Shortlink;

        var temp=$("<input>");
        $("body").append(temp);
        temp.val(link).select();
        document.execCommand("copy");
        temp.remove();

        $(this).html("Link copied <i class='fa fa-check-circle' style='color:#0ad00a;'></i>");
    
    });

    try
    {
        $(".targetHiddenVal").html($(".hiddenVal").val());
    }
    catch
    {
        
    }
    


})