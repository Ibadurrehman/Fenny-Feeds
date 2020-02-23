
$('#FeaturedProperties').owlCarousel({
    loop: true,
    margin: 5,
    nav: true,
    dots: false,
    autoplay: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 5
        }
    }
});


$('#FeaturedProperties1').owlCarousel({
    loop: true,
    margin: 5,
    nav: true,
    dots: false,
    autoplay: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 3
        }
    }
});


    $(document).ready(function () {
        $('#mo-number').mask('00000-00000');
    });

    //$("#city, #state, #country").select2({
    //    placeholder: 'Select an option'
    //});
    //$('#ddlPet_Gender, #ddlPet_Breed, #ddlPet_Age, #ddlPet_Weight, #ddlCity, #ddlState').select2({
    //    minimumResultsForSearch: Infinity
    //});