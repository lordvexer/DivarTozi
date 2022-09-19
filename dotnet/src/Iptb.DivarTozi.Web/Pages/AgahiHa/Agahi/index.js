$(function () {

    var l = abp.localization.getResource('DivarTozi');

    var service = iptb.divarTozi.agahiHa.agahi;
    var createModal = new abp.ModalManager(abp.appPath + 'AgahiHa/Agahi/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'AgahiHa/Agahi/EditModal');

    var dataTable = $('#AgahiTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('DivarTozi.Agahi.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DivarTozi.Agahi.Delete'),
                                confirmMessage: function (data) {
                                    return l('AgahiDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('AgahiRegionId'),
                data: "regionId"
            },
            {
                title: l('AgahiTitle'),
                data: "title"
            },
            {
                title: l('AgahiOfficeName'),
                data: "officeName"
            },
            {
                title: l('AgahiBrief'),
                data: "brief"
            },
            {
                title: l('AgahiReleaseDate'),
                data: "releaseDate"
            },
            {
                title: l('AgahiDastebandiId'),
                data: "dastebandiId"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAgahiButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
