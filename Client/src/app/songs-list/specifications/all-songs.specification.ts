import { Observable, of } from "rxjs";
import { Song } from "src/app/core/models/song.model";
import { SongsService } from "src/app/core/services/data/songs.service";
import { SongListSpecification } from "../intrefaces/song-list-specification";

export class AllSongsSpecification implements SongListSpecification {
    get(service: SongsService, count: number, offset: number): Observable<Song[]> {
        return service.getMany(count, offset);
    }
}