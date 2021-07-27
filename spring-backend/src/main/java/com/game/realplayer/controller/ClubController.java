package com.game.realplayer.controller;

import com.game.realplayer.repository.ClubRepo;
import com.game.realplayer.entity.Club;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("club")
public class ClubController {
    @Autowired
    private ClubRepo clubRepo;

    @PostMapping
    public HttpStatus insertClub(@RequestBody Club club){
        clubRepo.save(club);
        return HttpStatus.ACCEPTED;
    }
    @GetMapping
    public List<Club> allClubs(){
        return clubRepo.findAll();
    }
}
