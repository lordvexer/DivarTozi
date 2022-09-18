$(function () {

    var l = abp.localization.getResource('DivarTozi');

    var service = iptb.divarTozi.mantageHa.mantage;
    var createModal = new abp.ModalManager(abp.appPath + 'MantageHa/Mantage/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'MantageHa/Mantage/EditModal');

    var dataTable = $('#MantageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DivarTozi.Mantage.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DivarTozi.Mantage.Delete'),
                                confirmMessage: function (data) {
                                    return l('MantageDeletionConfirmationMessage', data.record.id);
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
                title: l('MantageName'),
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

    $('#NewMantageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
