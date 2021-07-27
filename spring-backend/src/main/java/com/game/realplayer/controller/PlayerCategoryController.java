package com.game.realplayer.controller;

import com.game.realplayer.entity.player.PlayerCategory;
import com.game.realplayer.repository.PlayerCategoryRepository;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping("/playerCategories")
public class PlayerCategoryController {

    private final PlayerCategoryRepository  playerCategoryRepository;

    @GetMapping
    public ResponseEntity<List<PlayerCategory>> allCategories(){
        List<PlayerCategory> categoryList = playerCategoryRepository.findAll();
        return new ResponseEntity<>(categoryList, HttpStatus.FOUND);
    }
    @PostMapping
    public ResponseEntity<PlayerCategory> addCategory(@RequestBody PlayerCategory playerCategory){
        PlayerCategory category = playerCategoryRepository.save(playerCategory);
        return new ResponseEntity<>(category, HttpStatus.CREATED);
    }
}
