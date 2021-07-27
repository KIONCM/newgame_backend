package com.game.realplayer.controller;

import com.game.realplayer.entity.club.ClubCategory;
import com.game.realplayer.repository.ClubCategoryRepository;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

@RestController
@AllArgsConstructor
@RequestMapping("/ClubCategories")
public class ClubCategoryController {
    private final ClubCategoryRepository clubCategoryRepository;
    @GetMapping
    public HttpStatus allClubs(){
      clubCategoryRepository.findAll();
        return HttpStatus.FOUND;
    }
    @PostMapping
    public HttpStatus addCategory(@RequestBody ClubCategory category){
        clubCategoryRepository.save(category);
        return HttpStatus.CREATED;
    }
}
