package com.game.realplayer.repository;

import com.game.realplayer.entity.player.PlayerCategory;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface PlayerCategoryRepository extends JpaRepository<PlayerCategory,Long> {
}
