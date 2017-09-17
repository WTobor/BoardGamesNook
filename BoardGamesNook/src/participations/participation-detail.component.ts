import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { ParticipationService } from "./participation.service";
import { Participation } from "./participation";

import { Common } from "./../Common";

@Component({
    selector: "participation-detail",
    templateUrl: "./src/participations/participation-detail.component.html"
})
export class ParticipationDetailComponent implements OnInit {
    participation: Participation;
    isCurrentGamer: boolean = false;

    constructor(
        private participationService: ParticipationService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.participationService.getParticipation(params["id"]))
            .subscribe((participation: Participation) => {
                this.participation = participation;
                if (this.participation.Id == undefined) {
                    this.isCurrentGamer = true;
                }
            });
    }

    //TODO: delete

    save(): void {
        var loc = this.location;
        if (this.participation.Id === undefined) {
            this.participationService.create(this.participation)
                .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        }
        else {
            this.participationService.update(this.participation)
                .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        }
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}