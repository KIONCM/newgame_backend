package com.game.realplayer.repository;

import com.game.realplayer.entity.club.ClubCategory;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ClubCategoryRepository extends JpaRepository<ClubCategory, Long> {
}
