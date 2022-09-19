$(function () {

    var l = abp.localization.getResource('DivarTozi');

    var service = iptb.divarTozi.dastebandiHa.dastebandi;
    var createModal = new abp.ModalManager(abp.appPath + 'DastebandiHa/Dastebandi/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'DastebandiHa/Dastebandi/EditModal');

    var dataTable = $('#DastebandiTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DivarTozi.Dastebandi.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DivarTozi.Dastebandi.Delete'),
                                confirmMessage: function (data) {
                                    return l('DastebandiDeletionConfirmationMessage', data.record.id);
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
                title: l('DastebandiName'),
                data: "name"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDastebandiButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
