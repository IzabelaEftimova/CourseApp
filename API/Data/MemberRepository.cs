using System;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class MemberRepository(AppDbContext context) : IMemberRepository
{
    async Task<Member?> IMemberRepository.GetMemberByIdAsync(string id)
    {
        return await context.Members.FindAsync(id);
    }

    public async Task<Member?> GetMemberForUpdate(string id)
    {
        return await context.Members
            .Include(x => x.User)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    async Task<IReadOnlyList<Member>> IMemberRepository.GetMembersAsync()
    {
        return await context.Members.ToListAsync();
    }

    async Task<IReadOnlyList<Photo>> IMemberRepository.GetPhotosForMembersAsync(string memberId)
    {
        return await context.Members.Where(x => x.Id == memberId).SelectMany(x => x.Photos).ToListAsync();
    }

    async Task<bool> IMemberRepository.SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    void IMemberRepository.Update(Member member)
    {
        context.Entry(member).State = EntityState.Modified;
    }
}
