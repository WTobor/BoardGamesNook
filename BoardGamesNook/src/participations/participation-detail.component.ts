import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
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
    isCurrentGamer = false;

    constructor(
        private participationService: ParticipationService,
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit() {
        this.participationService.getParticipation(Number(this.route.snapshot.paramMap.get("id")))
            .subscribe((participation: Participation) => {
                this.participation = participation;
                if (this.participation.Id == undefined) {
                    this.isCurrentGamer = true;
                }
            });
    }

    //TODO: deactivate

    save(): void {
        var loc = this.location;
        if (this.participation.Id === undefined) {
            this.participationService.create(this.participation)
                .subscribe(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        } else {
            this.participationService.update(this.participation)
                .subscribe(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        }
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}