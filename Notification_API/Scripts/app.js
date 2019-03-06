var currentList = {}
function showReportList(id) {
    $("#Report").html(currentList.name);
    

    $("#Home").hide();
    $("#Report").show();

   
}
function showHome(id) {
  


    $("#Home").show();
    $("#Report").hide();


}