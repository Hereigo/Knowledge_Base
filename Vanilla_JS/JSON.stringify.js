
let string = JSON.stringify({ squirrel: false, events: ["weekend"] });

console.log(string);  // {"squirrel":false,"events":["weekend"]};

console.log(JSON.parse(string).events);  // ['weekend']

// ========================================

var test = {
    "id": 1,
    "changedFields": {
        "System.State": "Active",
        "System.Reason": "Approved",
        "System.AssignedTo": "",
        "Microsoft.VSTS.Common.ActivatedBy": "Andrew <andrew@hotmail.com>",
        "Microsoft.VSTS.Common.ActivatedDate": {
            "type": 1
        },
        "Microsoft.VSTS.Common.ClosedDate": null,
        "Microsoft.VSTS.Common.ResolvedBy": "",
        "Microsoft.VSTS.Common.ResolvedDate": null,
        "Microsoft.VSTS.Common.ResolvedReason": "",
        "Microsoft.VSTS.Common.StateChangeDate": {
            "type": 1,
            "value": "2019-12-02T10:08:55.267Z"
        },
        "Microsoft.VSTS.Common.ClosedBy": ""
    }
};

console.log(test.changedFields['Microsoft.VSTS.Common.StateChangeDate']['value']);
// 2019-12-02T10:08:55.267Z