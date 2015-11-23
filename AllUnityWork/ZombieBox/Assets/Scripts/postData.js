/*#pragma strict

function Start () {
    createAjaxRequest();
}

var createAjaxRequest = function(e) {
    e.preventDefault();

    user_params = {user_id: 1, total_points: 2000, total_kills:4000, weapons: [{ weapon_id: 30, kill_count: 15, damage: 65, ammo: 99 }], skins: [{ skin_id: 64, kill_count: 345 }]};

   // var ajaxRequest = $.ajax({
        url: 'https://nameless-harbor-4730.herokuapp.com/update_all_user_details',
        type: "POST",
        data: { user_params: JSON.stringify(user_params) },
        dataType: 'json'
    });

    ajaxRequest.done(successResponse);
    ajaxRequest.fail(failedResponse);
};

var successResponse = function(data) {
    debugger
    // Do Success stuff
};

var failedResponse = function(data) {
    debugger
    // 500, 422, 400, etc
};*/