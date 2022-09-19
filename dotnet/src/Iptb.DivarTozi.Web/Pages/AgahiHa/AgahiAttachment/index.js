$(function () {

    var l = abp.localization.getResource('DivarTozi');

    var service = iptb.divarTozi.agahiHa.agahiAttachment;
    const getQueryString = (paramName) => {
        const urlSearchParams = new URLSearchParams(window.location.search);
        const params = Object.fromEntries(urlSearchParams.entries());
        return params[paramName];
    }

    var inputAction = function (requestData, dataTableSettings) {
        var requestO = {
            id: $('#AgahiId').val(),
        };
        return requestO;
    };

    var responseCallback = function (result) {
        return {
            recordsTotal: result.totalCount,
            recordsFiltered: result.totalCount,
            data: result.items
        };
    };
    
    var dataTable = $('#AgahiAttachmentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getListById, inputAction, responseCallback),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DivarTozi.AgahiAttachment.Delete'),
                                confirmMessage: function (data) {
                                    return l('AgahiAttachmentDeletionConfirmationMessage', data.record.fileName);
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
                title: l('View'),
                data: "",
                render: function (data, index, row, ee) {
                    return `<a target="_blank" href="/agahi/photos/${row.id}">${l("View")}</a>`
                }
            },
            {
                title: l('AgahiAttachmentFileName'),
                data: "fileName"
            },
            {
                title: l('AgahiAttachmentFileExtension'),
                data: "fileExtension"
            },
            {
                title: l('AgahiAttachmentDescription'),
                data: "description"
            },
        ]
    }));

    let myDropzone = Dropzone.forElement("#my-awesome-dropzone");
    myDropzone.on("complete", function (file) {
        myDropzone.removeFile(file);
        dataTable.ajax.reload();
    });
    $('.dz-button').html(l("DropFilesHereToUpload"));
    
});
