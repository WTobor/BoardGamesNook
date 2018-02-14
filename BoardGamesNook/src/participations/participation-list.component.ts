import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { ParticipationService } from "./participation.service";
import { Participation } from "./participation";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "participation-list",
    templateUrl: "./src/participations/participation-list.component.html"
})
export class ParticipationListComponent implements OnInit {
    participations: Participation[];
    selectedParticipation: Participation;
    selectedGamerNickname: string;
    isCurrentGamer: boolean = false;

    constructor(
        private participationService: ParticipationService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.selectedGamerNickname = this.route.snapshot.paramMap.get('gamerNickname');
        this.participationService.getParticipationsByGamerNickname(this.selectedGamerNickname)
            .subscribe((participationList: Participation[]) => {
                this.participations = participationList;
            });
        
        this.gamerService.getCurrentGamerNickname().subscribe(nickname => {
            if (nickname === this.selectedGamerNickname) {
                this.isCurrentGamer = true;
            }
        });
    }

    onSelect(participation: Participation): void {
        this.selectedParticipation = participation;
    }

    deactivate(participation: Participation): void {
        this.participationService
            .deactivate(participation.Id)
            .subscribe(() => {
                this.participations = this.participations.filter(g => g !== participation);
                if (this.selectedParticipation === participation) { this.selectedParticipation = null; }
            });
    }

    gotoAdd(): void {
        this.router.navigate(["/participation", 0]);
    }
}